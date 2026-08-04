using System;
using System.Collections.Generic;
using System.Linq;
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
    private readonly IBenchmarkAgent _benchmarkAgent;

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

            // Stage 2.5: Benchmark Engine (Execution Sandbox)
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
            if (issues.Count > 0)
            {
                onProgress(new ScanProgress(request.Id, ScanStage.RunningAiAnalysis, 75, "Running AI performance reviews..."));

                // Dynamic sizing: If MaxAiEvaluations <= 0, process ALL issues dynamically.
                // Otherwise, take up to MaxAiEvaluations.
                var issuesToAnalyze = (request.MaxAiEvaluations <= 0) 
                    ? issues 
                    : issues.Take(request.MaxAiEvaluations).ToList();

                // Process AI calls in parallel to maximize throughput & push updates to UI
                int completedAiCount = 0;
                var aiTasks = issuesToAnalyze.Select(async issue =>
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    issue.AiAnalysis = await _aiReviewAgent.AnalyzeIssueAsync(issue, cancellationToken);
                    
                    int currentCount = Interlocked.Increment(ref completedAiCount);
                    onProgress(new ScanProgress(
                        request.Id, 
                        ScanStage.RunningAiAnalysis, 
                        75 + (int)((currentCount / (double)issuesToAnalyze.Count) * 10), 
                        $"Completed AI analysis for issue {currentCount} of {issuesToAnalyze.Count}", 
                        issue));
                });

                await Task.WhenAll(aiTasks);
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