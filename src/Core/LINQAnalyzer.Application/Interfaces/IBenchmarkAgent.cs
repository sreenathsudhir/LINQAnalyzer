using System.Threading.Tasks;
using LINQAnalyzer.Domain.Models;

namespace LINQAnalyzer.Application.Interfaces;

/// <summary>
/// Represents estimated execution metrics and simulated SQL translation output for a code snippet.
/// </summary>
public record BenchmarkResult(
    long EstimatedAllocatedBytes,
    double ExecutionTimeMs,
    string ExecutedSql
);

public interface IBenchmarkAgent
{
    Task<BenchmarkResult> BenchmarkSnippetAsync(string codeSnippet);
    
    /// <summary>
    /// Generates standalone, compilable BenchmarkDotNet C# source code for an issue.
    /// </summary>
    string GenerateBenchmarkHarness(DiscoveredIssue issue, string refactoredCode);
}