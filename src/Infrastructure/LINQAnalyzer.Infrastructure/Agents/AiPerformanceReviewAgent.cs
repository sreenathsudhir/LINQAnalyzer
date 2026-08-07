using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LINQAnalyzer.Application.Interfaces;
using LINQAnalyzer.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace LINQAnalyzer.Infrastructure.Agents;

/// <summary>
/// Agent 3: Evaluates performance anti-patterns using a generic OpenAI-compatible LLM Gateway API.
/// </summary>
public class AiPerformanceReviewAgent : IAiReviewAgent
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _baseUrl;
    private readonly string _model;

    public AiPerformanceReviewAgent(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;

        // Strictly generic environment and configuration resolution
        _apiKey = Environment.GetEnvironmentVariable("LLM_API_KEY")
                  ?? Environment.GetEnvironmentVariable("LlmSettings__ApiKey")
                  ?? configuration["LlmSettings:ApiKey"]
                  ?? configuration["LLM_API_KEY"]
                  ?? string.Empty;

        _baseUrl = Environment.GetEnvironmentVariable("LLM_BASE_URL")
                   ?? Environment.GetEnvironmentVariable("LlmSettings__BaseUrl")
                   ?? configuration["LlmSettings:BaseUrl"]
                   ?? configuration["LLM_BASE_URL"]
                   ?? string.Empty;

        _model = Environment.GetEnvironmentVariable("LLM_MODEL")
                 ?? Environment.GetEnvironmentVariable("LlmSettings__Model")
                 ?? configuration["LlmSettings:Model"]
                 ?? configuration["LLM_MODEL"]
                 ?? "gpt-4o-mini";
    }

    public async Task<string> AnalyzeIssueAsync(DiscoveredIssue issue, CancellationToken cancellationToken = default)
    {
        var reviewResult = await ReviewIssueInternalAsync(issue, cancellationToken);

        if (!string.IsNullOrEmpty(reviewResult.RootCause) && reviewResult.RootCause.Contains("LLM_API_KEY is not configured"))
        {
            return reviewResult.RootCause;
        }

        return "### 💡 AI Root Cause Analysis\n" +
               reviewResult.RootCause + "\n\n" +
               "### ⚡ Performance Impact\n" +
               reviewResult.PerformanceImpact + "\n\n" +
               "### 🛠️ Refactored Solution\n" +
               "```csharp\n" + reviewResult.RefactoredCode + "\n```\n\n" +
               "### 📌 Recommendation\n" +
               reviewResult.Recommendation;
    }

    private async Task<AiReviewResult> ReviewIssueInternalAsync(DiscoveredIssue issue, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(_apiKey))
        {
            return new AiReviewResult
            {
                RuleId = issue.RuleId,
                RootCause = "LLM_API_KEY is not configured in environment variables (.env) or configuration.",
                RefactoredCode = issue.Snippet,
                Recommendation = "Add `LLM_API_KEY=your_key` to your local .env file to enable AI reviews."
            };
        }

        string prompt = "You are a senior .NET Performance Engineer.\n" +
            "Roslyn AST scanning detected a performance anti-pattern in C# code.\n\n" +
            "Rule ID: " + issue.RuleId + " (" + issue.RuleName + ")\n" +
            "File: " + issue.FilePath + " (Line " + issue.LineNumber + ")\n" +
            "Code Snippet:\n" + issue.Snippet + "\n\n" +
            "Respond strictly in JSON format with keys: rootCause, performanceImpact, refactoredCode, recommendation.";

        try
        {
            // Normalize URL path to safely handle endpoints with or without trailing /chat/completions
            string baseUrlNormalized = _baseUrl.TrimEnd('/');
            string requestUri = baseUrlNormalized.EndsWith("/chat/completions", StringComparison.OrdinalIgnoreCase)
                ? baseUrlNormalized
                : $"{baseUrlNormalized}/chat/completions";

            using var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey.Trim());

            var requestBody = new
            {
                model = _model,
                messages = new[]
                {
                    new { role = "user", content = prompt }
                },
                temperature = 0.2,
                response_format = new { type = "json_object" }
            };

            string jsonPayload = JsonSerializer.Serialize(requestBody);
            request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            using var response = await _httpClient.SendAsync(request, cancellationToken);
            string responseString = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("HTTP " + (int)response.StatusCode + ": " + responseString);
            }

            using var doc = JsonDocument.Parse(responseString);
            string content = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString() ?? "{}";

            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<AiReviewResult>(content, jsonOptions) ?? new AiReviewResult();
            result.RuleId = issue.RuleId;

            return result;
        }
        catch (Exception ex)
        {
            return new AiReviewResult
            {
                RuleId = issue.RuleId,
                RootCause = "AI Evaluation Error: " + ex.Message,
                RefactoredCode = issue.Snippet,
                Recommendation = "Review manual refactoring guidelines."
            };
        }
    }
}