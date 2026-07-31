namespace LINQAnalyzer.Domain.Models;

public record DiscoveredIssue(
    string RuleId,
    string RuleName,
    string FilePath,
    int LineNumber,
    string Snippet
)
{
    public string? AiAnalysis { get; set; }

    // Day 4: Execution Sandbox Metrics
    public long EstimatedAllocatedBytes { get; set; }
    public double ExecutionTimeMs { get; set; }
    public string? SimulatedSql { get; set; }
}