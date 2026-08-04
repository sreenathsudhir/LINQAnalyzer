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

public class AiPerformanceReviewAgent : IAiReviewAgent
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public AiPerformanceReviewAgent(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;

        // Fallback chain:
        // 1. GROQ_API_KEY environment variable
        // 2. Groq:ApiKey from User Secrets or appsettings.json
        _apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY")
                  ?? configuration["Groq:ApiKey"]
                  ?? string.Empty;
    }

    /// <summary>
    /// Orchestrator entry point required by IAiReviewAgent.
    /// Analyzes a discovered issue and returns a clean, formatted AI summary string.
    /// </summary>
    public async Task<string> AnalyzeIssueAsync(DiscoveredIssue issue, CancellationToken cancellationToken = default)
    {
        var reviewResult = await ReviewIssueInternalAsync(issue, cancellationToken);

        if (!string.IsNullOrEmpty(reviewResult.RootCause) && reviewResult.RootCause.StartsWith("GROQ_API_KEY"))
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

    /// <summary>
    /// Sends prompt to Groq LLM and deserializes JSON response into AiReviewResult.
    /// </summary>
    private async Task<AiReviewResult> ReviewIssueInternalAsync(DiscoveredIssue issue, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(_apiKey))
        {
            return new AiReviewResult
            {
                RuleId = issue.RuleId,
                RootCause = "GROQ_API_KEY is not configured in environment variables or User Secrets.",
                RefactoredCode = issue.Snippet,
                Recommendation = "Run `dotnet user-secrets set \"Groq:ApiKey\" \"your_key\"` to enable AI reviews."
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
            var requestUri = "https://api.groq.com/openai/v1/chat/completions";
            using var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            var requestBody = new
            {
                model = "llama-3.3-70b-versatile",
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