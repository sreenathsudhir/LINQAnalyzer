using LINQAnalyzer.Domain.Models;

namespace LINQAnalyzer.Application.Interfaces;

// Agent 1: Code Discovery Agent
public interface ICodeDiscoveryAgent
{
    Task<string> CloneRepositoryAsync(ScanRequest request, CancellationToken cancellationToken = default);
    void CleanupRepository(string localPath);
}

// Agent 2: Performance Analysis Agent (Roslyn AST Engine)
public interface IPerformanceAnalysisAgent
{
    Task<List<DiscoveredIssue>> AnalyzeCodebaseAsync(
        string localPath, 
        List<string> activeRuleIds, 
        Action<DiscoveredIssue> onIssueFound, 
        CancellationToken cancellationToken = default);
}

// Agent 3: AI Performance Review Agent (QBurst Gateway)
public interface IAiReviewAgent
{
    Task<string> AnalyzeIssueAsync(DiscoveredIssue issue, CancellationToken cancellationToken = default);
}

// Agent 4: SQL Optimization Agent (Static EF Checks)
public interface ISqlOptimizationAgent
{
    Task<List<DiscoveredIssue>> AnalyzeEfQueriesAsync(string localPath, CancellationToken cancellationToken = default);
}

// Agent 6: Documentation Agent (Report Generator)
public interface IDocumentationAgent
{
    Task<string> GenerateHtmlReportAsync(ScanRequest request, List<DiscoveredIssue> issues);
    Task<string> GenerateMarkdownReportAsync(ScanRequest request, List<DiscoveredIssue> issues);
}