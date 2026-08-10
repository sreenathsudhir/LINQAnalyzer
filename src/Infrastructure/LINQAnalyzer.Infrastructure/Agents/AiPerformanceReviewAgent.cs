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

        var sb = new StringBuilder();
        sb.AppendLine("### 💡 AI Root Cause Analysis");
        sb.AppendLine(reviewResult.RootCause);
        sb.AppendLine();
        sb.AppendLine("### ⚡ Performance Impact");
        sb.AppendLine(reviewResult.PerformanceImpact);
        sb.AppendLine();
        sb.AppendLine("### 🛠️ Refactored Solution");
        sb.AppendLine("```csharp");
        sb.AppendLine(reviewResult.RefactoredCode);
        sb.AppendLine("```");
        sb.AppendLine();

        if (!string.IsNullOrWhiteSpace(reviewResult.DetailedExplanation))
        {
            sb.AppendLine("### 📖 Detailed Technical Walkthrough");
            sb.AppendLine(reviewResult.DetailedExplanation);
            sb.AppendLine();
        }

        if (!string.IsNullOrWhiteSpace(reviewResult.PotentialPitfalls))
        {
            sb.AppendLine("### ⚠️ Potential Pitfalls & Edge Cases");
            sb.AppendLine(reviewResult.PotentialPitfalls);
            sb.AppendLine();
        }

        sb.AppendLine("### 📌 Recommendation");
        sb.Append(reviewResult.Recommendation);

        return sb.ToString();
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

        // Using concatenation for backticks prevents markdown formatting conflicts in response viewers
        string backticks = "```";
        string prompt = $@"
You are a principal .NET and EF Core Performance Engineer.
Roslyn AST scanning detected a performance anti-pattern in a C# codebase.

Rule ID: {issue.RuleId} ({issue.RuleName})
File: {issue.FilePath} (Line {issue.LineNumber})
Code Snippet:
{backticks}csharp
{issue.Snippet}
{backticks}

Provide an in-depth, production-grade technical review.
Respond strictly in JSON format with the following keys:
- rootCause: Deep technical root cause explaining why this code pattern harms execution efficiency at the OS/CLR or database level.
- performanceImpact: Specific runtime impact (e.g., thread pool starvation, memory allocation overhead, excessive SQL roundtrips, I/O blocking).
- refactoredCode: Complete, compilable, and production-ready C# refactored code showing method context, cancellation tokens, or async keywords where necessary.
- detailedExplanation: Step-by-step walkthrough explaining how the fix solves the underlying problem under the hood in EF Core/LINQ.
- potentialPitfalls: Edge cases, memory/tracking considerations, or breaking changes developers should be aware of when applying this fix.
- recommendation: Actionable architectural guidance and best practices for the team.
";

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