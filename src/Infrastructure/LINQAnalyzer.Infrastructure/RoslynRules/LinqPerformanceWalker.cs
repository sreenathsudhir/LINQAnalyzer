using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using LINQAnalyzer.Domain.Models;

namespace LINQAnalyzer.Infrastructure.RoslynRules;

/// <summary>
/// Roslyn Syntax Walker that inspects the Abstract Syntax Tree (AST) of C# code to flag LINQ performance anti-patterns.
/// </summary>
public class LinqPerformanceWalker : CSharpSyntaxWalker
{
    private readonly string _filePath;
    private readonly Action<DiscoveredIssue> _onIssueFound;
    private readonly HashSet<int> _flaggedLines = new();

    /// <summary>
    /// Initializes a new AST Walker for a single file.
    /// </summary>
    /// <param name="filePath">Relative file path for reporting context.</param>
    /// <param name="onIssueFound">Callback invoked immediately when an anti-pattern is flagged.</param>
    public LinqPerformanceWalker(string filePath, Action<DiscoveredIssue> onIssueFound)
    {
        _filePath = filePath;
        _onIssueFound = onIssueFound;
    }

    /// <summary>
    /// Overrides invocation inspection to catch method call expressions (e.g., .Count(), .ToList()).
    /// </summary>
    public override void VisitInvocationExpression(InvocationExpressionSyntax node)
    {
        string expressionText = node.ToString();

        // Line number calculation from the AST location span
        var lineSpan = node.GetLocation().GetLineSpan();
        int lineNumber = lineSpan.StartLinePosition.Line + 1;

        // RULE 1: Count() vs Any() or Count property check
        if (expressionText.Contains(".Count()"))
        {
            FlagIssue("RULE001", ".Count() Usage Check", lineNumber, expressionText);
        }

        // RULE 2: Premature ToList() materialization before filtering/projection
        if (expressionText.Contains(".ToList().Where(") || expressionText.Contains(".ToList().Select("))
        {
            FlagIssue("RULE002", "Premature Materialization (.ToList)", lineNumber, expressionText);
        }

        // Continue walking down the AST tree
        base.VisitInvocationExpression(node);
    }

    /// <summary>
    /// Emits a discovered issue while avoiding duplicate flags on the same line of code.
    /// </summary>
    private void FlagIssue(string ruleId, string ruleName, int lineNumber, string snippet)
    {
        if (_flaggedLines.Add(lineNumber))
        {
            var issue = new DiscoveredIssue(ruleId, ruleName, _filePath, lineNumber, snippet);
            _onIssueFound(issue);
        }
    }
}