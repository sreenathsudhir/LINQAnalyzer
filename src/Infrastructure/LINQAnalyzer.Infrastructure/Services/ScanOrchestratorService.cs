using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LINQAnalyzer.Application.Interfaces;
using LINQAnalyzer.Domain.Models;

namespace LINQAnalyzer.Infrastructure.Services;

/// <summary>
/// Pipeline orchestrator that coordinates Agents to execute the full scan job.
/// </summary>
public class ScanOrchestratorService
{
    private readonly ICodeDiscoveryAgent _discoveryAgent;
    private readonly IPerformanceAnalysisAgent _analysisAgent;
    private readonly IAiReviewAgent _aiReviewAgent;
    private readonly IDocumentationAgent _documentationAgent;
    private readonly IBenchmarkAgent _benchmarkAgent; // Day 4

    public ScanOrchestratorService(
        ICodeDiscoveryAgent discoveryAgent,
        IPerformanceAnalysisAgent analysisAgent,
        IAiReviewAgent aiReviewAgent,
        IDocumentationAgent documentationAgent,
        IBenchmarkAgent benchmarkAgent)
    {
        _discoveryAgent = discoveryAgent;
        _analysisAgent = analysisAgent;
        _aiReviewAgent = aiReviewAgent;
        _documentationAgent = documentationAgent;
        _benchmarkAgent = benchmarkAgent;
    }

    public async Task<(List<DiscoveredIssue> Issues, string HtmlReport)> ExecuteScanAsync(
        ScanRequest request, 
        Action<ScanProgress> onProgress, 
        CancellationToken cancellationToken = default)
    {
        string? clonedPath = null;
        try
        {
            // Stage 1: Agent 1 - Clone Repo
            onProgress(new ScanProgress(request.Id, ScanStage.CloningRepository, 15, "Cloning repository..."));
            clonedPath = await _discoveryAgent.CloneRepositoryAsync(request, cancellationToken);

            // Stage 2: Agent 2 - Roslyn AST Scan
            onProgress(new ScanProgress(request.Id, ScanStage.ParsingRoslynAst, 40, "Executing Roslyn AST rules..."));
            var issues = await _analysisAgent.AnalyzeCodebaseAsync(
                clonedPath, 
                request.SelectedRuleIds, 
                issue => onProgress(new ScanProgress(request.Id, ScanStage.ParsingRoslynAst, 55, $"Flagged issue in {issue.FilePath}", issue)),
                cancellationToken);

            // Stage 2.5: Benchmark Engine (Day 4 Execution Sandbox)
            if (issues.Count > 0)
            {
                onProgress(new ScanProgress(request.Id, ScanStage.ParsingRoslynAst, 60, "Running execution sandbox & SQL simulations..."));
                foreach (var issue in issues)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    var benchmark = await _benchmarkAgent.BenchmarkSnippetAsync(issue.Snippet);
                    issue.EstimatedAllocatedBytes = benchmark.EstimatedAllocatedBytes;
                    issue.ExecutionTimeMs = benchmark.ExecutionTimeMs;
                    issue.SimulatedSql = benchmark.ExecutedSql;
                }
            }

            // Stage 3: Agent 3 - AI Review (QBurst Gateway)
            onProgress(new ScanProgress(request.Id, ScanStage.RunningAiAnalysis, 75, "Running AI performance reviews..."));
            int evaluationsCount = Math.Min(issues.Count, request.MaxAiEvaluations);
            for (int i = 0; i < evaluationsCount; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                issues[i].AiAnalysis = await _aiReviewAgent.AnalyzeIssueAsync(issues[i], cancellationToken);
            }

            // Stage 4: Agent 6 - Report Generation
            onProgress(new ScanProgress(request.Id, ScanStage.GeneratingReports, 90, "Generating final report..."));
            string htmlReport = await _documentationAgent.GenerateHtmlReportAsync(request, issues);

            onProgress(new ScanProgress(request.Id, ScanStage.Completed, 100, "Scan completed successfully!"));
            return (issues, htmlReport);
        }
        finally
        {
            if (clonedPath != null)
            {
                _discoveryAgent.CleanupRepository(clonedPath);
            }
        }
    }
}