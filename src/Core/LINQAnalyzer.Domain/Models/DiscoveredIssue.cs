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
}