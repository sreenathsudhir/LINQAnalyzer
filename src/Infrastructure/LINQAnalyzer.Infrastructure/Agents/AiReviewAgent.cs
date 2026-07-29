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
    /// Sends a flagged code snippet to the AI Gateway for expert performance analysis.
    /// </summary>
    /// <param name="issue">The anti-pattern detected by Roslyn in Agent 2.</param>
    /// <param name="cancellationToken">Async cancellation token.</param>
    /// <returns>AI-generated Markdown explanation and replacement code.</returns>
    public async Task<string> AnalyzeIssueAsync(DiscoveredIssue issue, CancellationToken cancellationToken = default)
    {
        // 1. Construct a structured engineering prompt
        var prompt = $"""
            You are a Senior .NET Performance Engineer specializing in LINQ and Entity Framework Core optimizations.
            
            An anti-pattern was flagged during static AST analysis:
            - **Rule Triggered:** {issue.RuleName} ({issue.RuleId})
            - **File Path:** {issue.FilePath} (Line {issue.LineNumber})
            - **Flagged Snippet:** 
            ```csharp
            {issue.Snippet}
            ```
            
            Please provide a concise analysis containing:
            1. **Root Cause:** Why this specific usage degrades execution time or memory allocation.
            2. **Optimized Solution:** Clean, ready-to-use C# code snippet replacing the inefficient code.
            3. **Performance Impact:** Brief estimate of CPU/Memory improvements (e.g., preventing unnecessary allocations or avoiding roundtrips).
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

            return aiText ?? "AI review generated an empty result.";
        }
        catch (Exception ex)
        {
            // Fallback gracefully so gateway unavailability doesn't crash the scanning job
            return $"*AI Analysis Unavailable:* Unable to reach QBurst Gateway. Details: {ex.Message}";
        }
    }
}