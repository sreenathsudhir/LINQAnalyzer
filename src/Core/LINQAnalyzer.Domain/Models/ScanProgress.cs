namespace LINQAnalyzer.Domain.Models;

public enum ScanStage
{
    Pending,
    CloningRepository,
    ParsingRoslynAst,
    RunningAiAnalysis,
    GeneratingReports,
    Completed,
    Failed
}

public record ScanProgress(
    Guid ScanId,
    ScanStage Stage,
    int PercentComplete,
    string Message,
    DiscoveredIssue? LatestIssue = null
);
