using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LINQAnalyzer.Application.Interfaces;
using LINQAnalyzer.Domain.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace LINQAnalyzer.Infrastructure.Agents;

public class PdfExportAgent : IPdfExportAgent
{
    static PdfExportAgent()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public byte[] GeneratePdfReport(ScanRequest request, List<DiscoveredIssue> issues)
    {
        var ruleSeverityMap = RuleRegistry.AvailableRules.ToDictionary(r => r.Id, r => r.Severity);

        RuleSeverity GetSeverity(string ruleId)
        {
            return ruleSeverityMap.TryGetValue(ruleId, out var sev) ? sev : RuleSeverity.Warning;
        }

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial"));

                // Header
                page.Header().Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("LINQ & EF Core Performance Report")
                            .FontSize(20).Bold().FontColor(Colors.Blue.Darken2);
                        col.Item().Text($"Repository: {request.GitUrl}")
                            .FontSize(10).FontColor(Colors.Grey.Medium);
                        col.Item().Text($"Branch: {request.Branch} | Generated: {DateTime.UtcNow:yyyy-MM-dd HH:mm} UTC")
                            .FontSize(9).FontColor(Colors.Grey.Medium);
                    });
                });

                // Content
                page.Content().PaddingVertical(1, Unit.Centimetre).Column(col =>
                {
                    // Executive Summary Box
                    col.Item().Background(Colors.Grey.Lighten3).Padding(10).Column(summary =>
                    {
                        summary.Item().Text("Executive Summary").FontSize(14).Bold();
                        summary.Item().Text($"Total Issues Detected: {issues.Count}");
                        summary.Item().Text($"Critical: {issues.Count(i => GetSeverity(i.RuleId) == RuleSeverity.Critical)} | Warning: {issues.Count(i => GetSeverity(i.RuleId) == RuleSeverity.Warning)} | Info: {issues.Count(i => GetSeverity(i.RuleId) == RuleSeverity.Info)}");
                    });

                    col.Item().Height(15);

                    // Detailed Issue Breakdown
                    if (!issues.Any())
                    {
                        col.Item().Text("🎉 No performance anti-patterns detected!").FontSize(12).Bold().FontColor(Colors.Green.Medium);
                    }
                    else
                    {
                        foreach (var issue in issues)
                        {
                            var severity = GetSeverity(issue.RuleId);
                            string severityColor = severity switch
                            {
                                RuleSeverity.Critical => Colors.Red.Medium,
                                RuleSeverity.Warning => Colors.Orange.Medium,
                                _ => Colors.Blue.Medium
                            };

                            col.Item().PaddingBottom(15).Border(1).BorderColor(Colors.Grey.Lighten2).Padding(10).Column(issueCol =>
                            {
                                // Header Row for Issue
                                issueCol.Item().Row(r =>
                                {
                                    r.RelativeItem().Text($"[{issue.RuleId}] {issue.RuleName}").FontSize(12).Bold();
                                    r.ConstantItem(80).AlignRight().Text(severity.ToString()).FontColor(severityColor).Bold();
                                });

                                issueCol.Item().Text($"Location: {issue.FilePath} (Line {issue.LineNumber})").FontSize(9).FontColor(Colors.Grey.Darken1);
                                issueCol.Item().Height(5);

                                // Snippet Box
                                issueCol.Item().Background(Colors.Grey.Lighten4).Padding(6).Text(issue.Snippet).FontFamily("Consolas").FontSize(8);

                                // AI Analysis Section (Includes Detailed Walkthroughs & Pitfalls)
                                if (!string.IsNullOrWhiteSpace(issue.AiAnalysis))
                                {
                                    issueCol.Item().Height(8);
                                    issueCol.Item().Text("AI Optimization & Guidance:").FontSize(10).Bold().FontColor(Colors.Blue.Darken2);
                                    issueCol.Item().Text(issue.AiAnalysis).FontSize(9);
                                }
                            });
                        }
                    }
                });

                // Footer
                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Generated by LINQAnalyzer | Page ");
                    x.CurrentPageNumber();
                    x.Span(" of ");
                    x.TotalPages();
                });
            });
        });

        return document.GeneratePdf();
    }
}