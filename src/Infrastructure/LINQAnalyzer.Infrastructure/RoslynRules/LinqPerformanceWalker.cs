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
    private readonly List<string> _activeRuleIds;
    private readonly Action<DiscoveredIssue> _onIssueFound;
    private readonly HashSet<string> _flaggedRulesPerLine = new();

    public LinqPerformanceWalker(
        string filePath, 
        List<string> activeRuleIds, 
        Action<DiscoveredIssue> onIssueFound)
    {
        _filePath = filePath;
        _activeRuleIds = activeRuleIds ?? new List<string>();
        _onIssueFound = onIssueFound;
    }

    // Binary expressions like `list.Count() > 0`
    public override void VisitBinaryExpression(BinaryExpressionSyntax node)
    {
        string expressionText = node.ToString();
        var lineSpan = node.GetLocation().GetLineSpan();
        int lineNumber = lineSpan.StartLinePosition.Line + 1;

        if (IsRuleActive("LINQ001") &&
            expressionText.Contains(".Count()") && 
           (node.IsKind(SyntaxKind.GreaterThanExpression) || node.IsKind(SyntaxKind.NotEqualsExpression) || node.IsKind(SyntaxKind.GreaterThanOrEqualExpression)))
        {
            FlagIssue("LINQ001", "Count() used instead of Any() for existence checks", lineNumber, expressionText);
        }

        base.VisitBinaryExpression(node);
    }

    public override void VisitInvocationExpression(InvocationExpressionSyntax node)
    {
        string expressionText = node.ToString();
        var lineSpan = node.GetLocation().GetLineSpan();
        int lineNumber = lineSpan.StartLinePosition.Line + 1;

        // LINQ001: Count() vs Any()
        if (IsRuleActive("LINQ001") && 
            expressionText.Contains(".Count()") && (expressionText.Contains("> 0") || expressionText.Contains("!= 0") || expressionText.Contains(">= 1")))
        {
            FlagIssue("LINQ001", "Count() used instead of Any() for existence checks", lineNumber, expressionText);
        }

        // LINQ002: Premature ToList() / ToArray() Execution
        if (IsRuleActive("LINQ002") && 
            (expressionText.Contains(".ToList().Where(") || expressionText.Contains(".ToArray().Where(")))
        {
            FlagIssue("LINQ002", "Premature ToList() / ToArray() Execution", lineNumber, expressionText);
        }

        // LINQ003: Missing Projection (.Select)
        if (IsRuleActive("LINQ003") && 
            (expressionText.Contains(".ToList()") || expressionText.Contains(".ToListAsync()")) && !expressionText.Contains(".Select("))
        {
            FlagIssue("LINQ003", "Missing Projection (.Select)", lineNumber, expressionText);
        }

        // LINQ004: Multiple Enumeration / Unfiltered In-Memory Query
        if (IsRuleActive("LINQ004") && 
            (expressionText.Contains(".AsEnumerable().Where(") || expressionText.Contains(".ToList().Where(")))
        {
            FlagIssue("LINQ004", "Multiple Enumeration / Unfiltered In-Memory Query", lineNumber, expressionText);
        }

        // EF001: Missing AsNoTracking() in Query Chain
        if (IsRuleActive("EF001") && 
            (expressionText.Contains(".ToListAsync()") || expressionText.Contains(".FirstOrDefaultAsync()") || expressionText.Contains(".ToList()"))
            && !expressionText.Contains(".AsNoTracking()"))
        {
            FlagIssue("EF001", "Missing AsNoTracking() in Read-Only Query", lineNumber, expressionText);
        }

        // EF003: Excessive / Deep .Include() Chain (Cartesian Explosion Risk)
        int includeCount = CountOccurrences(expressionText, ".Include(") + CountOccurrences(expressionText, ".ThenInclude(");
        if (IsRuleActive("EF003") && includeCount >= 2)
        {
            FlagIssue("EF003", "Excessive .Include() Chain / Cartesian Explosion Risk", lineNumber, expressionText);
        }

        // EF004: Synchronous DB Call in Async Context
        var containingMethod = node.Ancestors().OfType<MethodDeclarationSyntax>().FirstOrDefault();
        if (IsRuleActive("EF004") && containingMethod != null && containingMethod.Modifiers.Any(SyntaxKind.AsyncKeyword))
        {
            if (expressionText.EndsWith(".ToList()") || expressionText.EndsWith(".FirstOrDefault()") || expressionText.EndsWith(".SingleOrDefault()") || expressionText.EndsWith(".Count()"))
            {
                FlagIssue("EF004", "Synchronous DB Call in Async Method", lineNumber, expressionText);
            }
        }

        // EF005: Client-Side Evaluation Trap
        if (IsRuleActive("EF005") && expressionText.Contains(".Where(") && ContainsCustomMethodInPredicate(node))
        {
            FlagIssue("EF005", "Client-Side Evaluation Trap", lineNumber, expressionText);
        }

        base.VisitInvocationExpression(node);
    }

    public override void VisitForEachStatement(ForEachStatementSyntax node)
    {
        string statementText = node.ToString();
        var lineSpan = node.GetLocation().GetLineSpan();
        int lineNumber = lineSpan.StartLinePosition.Line + 1;

        // EF002: N+1 Query Pattern in Foreach Loop
        if (IsRuleActive("EF002") && 
            (statementText.Contains(".FirstOrDefault(") || statementText.Contains(".Where(") || statementText.Contains(".ToList(") || statementText.Contains(".Find(")))
        {
            FlagIssue("EF002", "N+1 Query Pattern in Foreach Loop", lineNumber, statementText);
        }

        base.VisitForEachStatement(node);
    }

    // LINQ005: LINQ Calls Inside Loop Conditions/Bodies
    public override void VisitForStatement(ForStatementSyntax node)
    {
        CheckLoopConditionForLinq("LINQ005", node.Condition?.ToString(), node.GetLocation());
        base.VisitForStatement(node);
    }

    public override void VisitWhileStatement(WhileStatementSyntax node)
    {
        CheckLoopConditionForLinq("LINQ005", node.Condition?.ToString(), node.GetLocation());
        base.VisitWhileStatement(node);
    }

    private void CheckLoopConditionForLinq(string ruleId, string? conditionText, Location location)
    {
        if (IsRuleActive(ruleId) && !string.IsNullOrEmpty(conditionText))
        {
            if (conditionText.Contains(".Count()") || conditionText.Contains(".Any()") || conditionText.Contains(".Where("))
            {
                int lineNumber = location.GetLineSpan().StartLinePosition.Line + 1;
                FlagIssue(ruleId, "Repeated LINQ Evaluation in Loop Condition", lineNumber, conditionText);
            }
        }
    }

    private bool IsRuleActive(string ruleId)
    {

        return _activeRuleIds.Count == 0 || _activeRuleIds.Contains(ruleId, StringComparer.OrdinalIgnoreCase);
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