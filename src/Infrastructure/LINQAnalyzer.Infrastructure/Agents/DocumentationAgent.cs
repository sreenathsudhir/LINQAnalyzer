using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LINQAnalyzer.Application.Interfaces;
using LINQAnalyzer.Domain.Models;

namespace LINQAnalyzer.Infrastructure.Agents;

/// <summary>
/// Agent 6: Converts scan metadata, AST findings, and AI reviews into clean Markdown and HTML reports.
/// </summary>
public class DocumentationAgent : IDocumentationAgent
{
    /// <summary>
    /// Generates a standalone, beautifully styled HTML report ready for download/viewing in browser.
    /// </summary>
    public Task<string> GenerateHtmlReportAsync(ScanRequest request, List<DiscoveredIssue> issues)
    {
        var sb = new StringBuilder();
        sb.AppendLine("<!DOCTYPE html>");
        sb.AppendLine("<html lang=\"en\">");
        sb.AppendLine("<head>");
        sb.AppendLine("<meta charset=\"UTF-8\">");
        sb.AppendLine("<title>LINQ Performance Analysis Report</title>");
        sb.AppendLine("<style>");
        sb.AppendLine("  body { font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif; margin: 30px; background: #f8f9fa; color: #212529; }");
        sb.AppendLine("  .card { background: white; padding: 20px; border-radius: 8px; box-shadow: 0 2px 4px rgba(0,0,0,0.1); margin-bottom: 20px; }");
        sb.AppendLine("  .badge { background: #dc3545; color: white; padding: 4px 8px; border-radius: 4px; font-size: 12px; }");
        sb.AppendLine("  pre { background: #272822; color: #f8f8f2; padding: 15px; border-radius: 5px; overflow-x: auto; }");
        sb.AppendLine("</style>");
        sb.AppendLine("</head><body>");

        sb.AppendLine($"<h1>🚀 LINQ Performance Analysis Report</h1>");
        sb.AppendLine($"<div class='card'><strong>Repository:</strong> {request.GitUrl}<br/><strong>Branch:</strong> {request.Branch}<br/><strong>Date:</strong> {DateTime.UtcNow:f} UTC</div>");

        sb.AppendLine($"<h2>Flagged Issues ({issues.Count})</h2>");
        foreach (var issue in issues)
        {
            sb.AppendLine("<div class='card'>");
            sb.AppendLine($"<h3><span class='badge'>{issue.RuleId}</span> {issue.RuleName}</h3>");
            sb.AppendLine($"<p><strong>File:</strong> {issue.FilePath} (Line {issue.LineNumber})</p>");
            sb.AppendLine($"<pre><code>{issue.Snippet}</code></pre>");
            if (!string.IsNullOrWhiteSpace(issue.AiAnalysis))
            {
                sb.AppendLine("<h4>AI Optimization Analysis</h4>");
                sb.AppendLine($"<div>{issue.AiAnalysis.Replace("\n", "<br/>")}</div>");
            }
            sb.AppendLine("</div>");
        }

        sb.AppendLine("</body></html>");
        return Task.FromResult(sb.ToString());
    }

    /// <summary>
    /// Generates a Markdown report suitable for PR comments or documentation repositories.
    /// </summary>
    public Task<string> GenerateMarkdownReportAsync(ScanRequest request, List<DiscoveredIssue> issues)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"# LINQ Performance Analysis Report");
        sb.AppendLine($"* **Repository:** `{request.GitUrl}`");
        sb.AppendLine($"* **Branch:** `{request.Branch}`");
        sb.AppendLine($"* **Total Issues:** {issues.Count}\n");

        foreach (var issue in issues)
        {
            sb.AppendLine($"### ⚠️ [{issue.RuleId}] {issue.RuleName}");
            sb.AppendLine($"* **Location:** `{issue.FilePath}:{issue.LineNumber}`");
            sb.AppendLine("```csharp");
            sb.AppendLine(issue.Snippet);
            sb.AppendLine("```");
            if (!string.IsNullOrWhiteSpace(issue.AiAnalysis))
            {
                sb.AppendLine("\n**AI Recommendation:**");
                sb.AppendLine(issue.AiAnalysis);
            }
            sb.AppendLine("\n---");
        }

        return Task.FromResult(sb.ToString());
    }
}