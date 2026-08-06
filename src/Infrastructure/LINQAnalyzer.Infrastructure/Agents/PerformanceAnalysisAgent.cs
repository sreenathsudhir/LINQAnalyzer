using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using LINQAnalyzer.Application.Interfaces;
using LINQAnalyzer.Domain.Models;
using LINQAnalyzer.Infrastructure.RoslynRules;

namespace LINQAnalyzer.Infrastructure.Agents;

/// <summary>
/// Agent 2: Scans C# source code files across a project, constructs Roslyn ASTs, and executes performance rules.
/// </summary>
public class PerformanceAnalysisAgent : IPerformanceAnalysisAgent
{
    /// <summary>
    /// Iterates through C# files, parses syntax trees, and invokes the AST Walker.
    /// </summary>
    /// <param name="localPath">Root path of cloned source code.</param>
    /// <param name="activeRuleIds">Selected rules from the UI form used for rule filtering.</param>
    /// <param name="onIssueFound">Real-time callback streamed back to UI.</param>
    /// <param name="cancellationToken">Cancellation token for async operations.</param>
    /// <returns>A full list of all discovered issues across the repository.</returns>
    public async Task<List<DiscoveredIssue>> AnalyzeCodebaseAsync(
        string localPath,
        List<string> activeRuleIds,
        Action<DiscoveredIssue> onIssueFound,
        CancellationToken cancellationToken = default)
    {
        var discoveredIssues = new List<DiscoveredIssue>();

        // Recursively find all C# source files in the local repository
        var csFiles = Directory.GetFiles(localPath, "*.cs", SearchOption.AllDirectories);

        foreach (var filePath in csFiles)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // Ignore generated build output artifacts to prevent false positives
            if (filePath.Contains("/obj/") || filePath.Contains("/bin/") ||
                filePath.Contains(@"\obj\") || filePath.Contains(@"\bin\"))
            {
                continue;
            }

            // Read source code file asynchronously
            string sourceCode = await File.ReadAllTextAsync(filePath, cancellationToken);

            // Parse C# text into an Abstract Syntax Tree (AST) using Roslyn APIs
            SyntaxTree tree = CSharpSyntaxTree.ParseText(sourceCode, cancellationToken: cancellationToken);
            SyntaxNode root = await tree.GetRootAsync(cancellationToken);

            string relativePath = Path.GetRelativePath(localPath, filePath);

            // Instantiate AST Walker passing activeRuleIds filter
            var walker = new LinqPerformanceWalker(relativePath, activeRuleIds, issue =>
            {
                discoveredIssues.Add(issue);
                onIssueFound(issue);
            });

            walker.Visit(root);
        }

        return discoveredIssues;
    }
}