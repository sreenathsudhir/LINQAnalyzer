using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LINQAnalyzer.Application.Interfaces;
using LINQAnalyzer.Domain.Models;

namespace LINQAnalyzer.Infrastructure.Agents;

/// <summary>
/// Agent 3: Connects to the QBurst LLM Gateway to evaluate flagged LINQ/EF code snippets,
/// explain root causes, assess memory/CPU impact, and generate optimized C# code fixes.
/// </summary>
public class AiReviewAgent : IAiReviewAgent
{
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Initializes the AI Review Agent with an injected HttpClient instance targeted at the QBurst Gateway.
    /// </summary>
    /// <param name="httpClient">Configured HTTP Client with QBurst Gateway base address & auth headers.</param>
    public AiReviewAgent(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Sends a flagged code snippet to the AI Gateway for expert performance analysis and refactoring recommendations.
    /// </summary>
    /// <param name="issue">The anti-pattern detected by Roslyn in Agent 2.</param>
    /// <param name="cancellationToken">Async cancellation token.</param>
    /// <returns>AI-generated Markdown explanation and replacement code.</returns>
    public async Task<string> AnalyzeIssueAsync(DiscoveredIssue issue, CancellationToken cancellationToken = default)
    {
        // 1. Construct a structured engineering prompt with defined Markdown sections for UI diffs
        var prompt = $"""
            You are a Senior .NET Performance Engineer specializing in Roslyn AST, LINQ, and EF Core query optimization.

            Analyze this flagged code issue:
            - **Rule Triggered:** {issue.RuleName} ({issue.RuleId})
            - **File Path:** {issue.FilePath} (Line {issue.LineNumber})
            - **Flagged Snippet:**
            ```csharp
            {issue.Snippet}
            ```

            Provide a response strictly formatted in Markdown with these two clear sections:

            ### 💡 Analysis & Impact
            Explain why this anti-pattern hurts execution time or memory allocation (e.g., memory allocations, extra DB round-trips, N+1 queries, or client-side evaluation).

            ### ⚡ Recommended Refactoring
            Provide the fully corrected, production-ready C# replacement snippet inside a ```csharp code block.
            """;

        // 2. Prepare payload matching standard LLM gateway schema
        var requestPayload = new
        {
            model = "qburst-default-llm", // Configurable routing model alias
            messages = new[]
            {
                new { role = "system", content = "You are an expert .NET performance analyzer." },
                new { role = "user", content = prompt }
            },
            temperature = 0.2 // Low temperature for deterministic code outputs
        };

        var jsonContent = new StringContent(
            JsonSerializer.Serialize(requestPayload),
            Encoding.UTF8,
            "application/json");

        try
        {
            // 3. Invoke QBurst LLM Gateway endpoint
            var response = await _httpClient.PostAsync("v1/chat/completions", jsonContent, cancellationToken);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync(cancellationToken);
            using var doc = JsonDocument.Parse(responseJson);

            // 4. Extract generated response text safely
            var aiText = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return aiText ?? GetFallbackAnalysis(issue, "AI review returned an empty result.");
        }
        catch (Exception ex)
        {
            // Fall back gracefully with mock suggestion so gateway unavailability doesn't crash the scanning job
            return GetFallbackAnalysis(issue, ex.Message);
        }
    }

    private static string GetFallbackAnalysis(DiscoveredIssue issue, string details)
    {
        return $"""
            ### 💡 Analysis & Impact
            This `{issue.RuleId}` pattern allocates unnecessary memory or triggers extra database round-trips during query execution.
            *(Note: QBurst AI Gateway unavailable — {details})*

            ### ⚡ Recommended Refactoring
            ```csharp
            // Optimized query replacement snippet:
            // Refactor '{issue.Snippet.Trim()}' to stream items or project fields directly.
            ```
            """;
    }
}