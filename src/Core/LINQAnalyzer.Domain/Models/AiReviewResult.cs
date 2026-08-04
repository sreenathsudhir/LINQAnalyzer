namespace LINQAnalyzer.Domain.Models;

/// <summary>
/// Represents the AI-generated analysis and refactoring solution for a discovered performance issue.
/// </summary>
public class AiReviewResult
{
    public string RuleId { get; set; } = string.Empty;
    public string RootCause { get; set; } = string.Empty;
    public string PerformanceImpact { get; set; } = string.Empty;
    public string RefactoredCode { get; set; } = string.Empty;
    public string Recommendation { get; set; } = string.Empty;
}