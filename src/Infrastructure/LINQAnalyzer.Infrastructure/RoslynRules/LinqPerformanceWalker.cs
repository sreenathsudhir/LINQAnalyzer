using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using LINQAnalyzer.Domain.Models;

namespace LINQAnalyzer.Infrastructure.RoslynRules;

/// <summary>
/// Roslyn Syntax Walker that inspects the Abstract Syntax Tree (AST) of C# code to flag LINQ & EF Core performance anti-patterns.
/// </summary>
public class LinqPerformanceWalker : CSharpSyntaxWalker
{
    private readonly string _filePath;
    private readonly Action<DiscoveredIssue> _onIssueFound;
    private readonly HashSet<string> _flaggedRulesPerLine = new();

    public LinqPerformanceWalker(string filePath, Action<DiscoveredIssue> onIssueFound)
    {
        _filePath = filePath;
        _onIssueFound = onIssueFound;
    }

    // Binary expressions like `list.Count() > 0`
    public override void VisitBinaryExpression(BinaryExpressionSyntax node)
    {
        string expressionText = node.ToString();
        var lineSpan = node.GetLocation().GetLineSpan();
        int lineNumber = lineSpan.StartLinePosition.Line + 1;

        if (expressionText.Contains(".Count()") && 
           (node.IsKind(SyntaxKind.GreaterThanExpression) || node.IsKind(SyntaxKind.NotEqualsExpression) || node.IsKind(SyntaxKind.GreaterThanOrEqualExpression)))
        {
            FlagIssue("LINQ001", "Count() used instead of Any()", lineNumber, expressionText);
        }

        base.VisitBinaryExpression(node);
    }

    public override void VisitInvocationExpression(InvocationExpressionSyntax node)
    {
        string expressionText = node.ToString();
        var lineSpan = node.GetLocation().GetLineSpan();
        int lineNumber = lineSpan.StartLinePosition.Line + 1;

        // LINQ001: Count() vs Any()
        if (expressionText.Contains(".Count()") && (expressionText.Contains("> 0") || expressionText.Contains("!= 0") || expressionText.Contains(">= 1")))
        {
            FlagIssue("LINQ001", "Count() used instead of Any()", lineNumber, expressionText);
        }

        // LINQ002: Premature ToList() / ToArray() Execution
        if (expressionText.Contains(".ToList().Where(") || expressionText.Contains(".ToArray().Where("))
        {
            FlagIssue("LINQ002", "Premature ToList() / ToArray() Execution", lineNumber, expressionText);
        }

        // LINQ003: Missing Projection (.Select) before ToList/ToListAsync
        if ((expressionText.Contains(".ToList()") || expressionText.Contains(".ToListAsync()")) && !expressionText.Contains(".Select("))
        {
            FlagIssue("LINQ003", "Missing Projection (.Select)", lineNumber, expressionText);
        }

        // LINQ004: Unfiltered In-Memory Query
        if (expressionText.Contains(".AsEnumerable().Where(") || expressionText.Contains(".ToList().Where("))
        {
            FlagIssue("LINQ004", "Unfiltered In-Memory Query", lineNumber, expressionText);
        }

        // EF001: Missing AsNoTracking() in Query Chain
        if ((expressionText.Contains(".ToListAsync()") || expressionText.Contains(".FirstOrDefaultAsync()") || expressionText.Contains(".ToList()"))
            && !expressionText.Contains(".AsNoTracking()"))
        {
            FlagIssue("EF001", "Missing AsNoTracking() in Read-Only Query", lineNumber, expressionText);
        }

        // EF003: Excessive / Deep .Include() Chain (3 or more)
        int includeCount = CountOccurrences(expressionText, ".Include(") + CountOccurrences(expressionText, ".ThenInclude(");
        if (includeCount >= 3)
        {
            FlagIssue("EF003", "Excessive / Deep .Include() Chain", lineNumber, expressionText);
        }

        // EF004: Synchronous DB Call in Async Context
        var containingMethod = node.Ancestors().OfType<MethodDeclarationSyntax>().FirstOrDefault();
        if (containingMethod != null && containingMethod.Modifiers.Any(SyntaxKind.AsyncKeyword))
        {
            if (expressionText.EndsWith(".ToList()") || expressionText.EndsWith(".FirstOrDefault()") || expressionText.EndsWith(".SingleOrDefault()") || expressionText.EndsWith(".Count()"))
            {
                FlagIssue("EF004", "Synchronous DB Call in Async Method", lineNumber, expressionText);
            }
        }

        // EF005: Cartesian Explosion Risk (Preserved exactly as your existing code)
        if (includeCount >= 2 && expressionText.Contains(".Include("))
        {
            FlagIssue("EF005", "Cartesian Explosion Risk", lineNumber, expressionText);
        }

        // EF006: Client-Side Evaluation Trap (Added safely)
        if (expressionText.Contains(".Where(") && ContainsCustomMethodInPredicate(node))
        {
            FlagIssue("EF006", "Client-Side Evaluation Trap", lineNumber, expressionText);
        }

        base.VisitInvocationExpression(node);
    }

    public override void VisitForEachStatement(ForEachStatementSyntax node)
    {
        string statementText = node.ToString();
        var lineSpan = node.GetLocation().GetLineSpan();
        int lineNumber = lineSpan.StartLinePosition.Line + 1;

        // EF002: N+1 Query Pattern in Foreach Loop
        if (statementText.Contains(".FirstOrDefault(") || statementText.Contains(".Where(") || statementText.Contains(".ToList(") || statementText.Contains(".Find("))
        {
            FlagIssue("EF002", "N+1 Query Pattern in Foreach Loop", lineNumber, statementText);
        }

        base.VisitForEachStatement(node);
    }

    private void FlagIssue(string ruleId, string ruleName, int lineNumber, string snippet)
    {
        string key = $"{ruleId}:{lineNumber}";
        if (_flaggedRulesPerLine.Add(key))
        {
            string cleanSnippet = snippet.Length > 120 ? snippet.Substring(0, 120) + "..." : snippet;
            var issue = new DiscoveredIssue(ruleId, ruleName, _filePath, lineNumber, cleanSnippet);
            _onIssueFound(issue);
        }
    }

    private static bool ContainsCustomMethodInPredicate(InvocationExpressionSyntax node)
    {
        return node.ArgumentList.Arguments.Any(arg => 
            arg.ToString().Contains("(") && 
            !arg.ToString().StartsWith("e =>") && 
            !arg.ToString().StartsWith("x =>") && 
            !arg.ToString().Contains("Convert."));
    }

    private static int CountOccurrences(string text, string pattern)
    {
        int count = 0, i = 0;
        while ((i = text.IndexOf(pattern, i, StringComparison.Ordinal)) != -1)
        {
            i += pattern.Length;
            count++;
        }
        return count;
    }
}