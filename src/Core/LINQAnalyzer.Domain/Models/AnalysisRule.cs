using System.Collections.Generic;

namespace LINQAnalyzer.Domain.Models;

public enum RuleCategory
{
    LINQ,
    EntityFramework,
    Memory
}

public enum RuleSeverity
{
    Info,
    Warning,
    Critical
}

public record AnalysisRule(
    string Id,
    string Name,
    string Description,
    RuleCategory Category,
    RuleSeverity Severity,
    bool IsEnabledByDefault = true
);

public static class RuleRegistry
{
    public static readonly List<AnalysisRule> AvailableRules = new()
    {
        new AnalysisRule(
            "LINQ001",
            "Count() used instead of Any()",
            "Calling .Count() > 0 evaluates the entire sequence, whereas .Any() terminates on the first match.",
            RuleCategory.LINQ,
            RuleSeverity.Warning
        ),
        new AnalysisRule(
            "LINQ002",
            "Premature ToList() / ToArray() Execution",
            "Materializing a query into memory before applying Where/Select filters prevents query optimization.",
            RuleCategory.LINQ,
            RuleSeverity.Critical
        ),
        new AnalysisRule(
            "LINQ003",
            "Missing Projection (.Select)",
            "Fetching full entity objects when only specific fields are needed increases heap allocations.",
            RuleCategory.LINQ,
            RuleSeverity.Warning
        ),
        new AnalysisRule(
            "LINQ004",
            "Unfiltered In-Memory Query",
            "Filtering via .Where() occurs after materializing data into memory (.ToList/.AsEnumerable), downloading unnecessary rows.",
            RuleCategory.Memory,
            RuleSeverity.Critical
        ),
        new AnalysisRule(
            "EF001",
            "Missing AsNoTracking() in Read-Only Query",
            "Queries executed for read-only purposes without .AsNoTracking() incur unnecessary EF change tracking overhead.",
            RuleCategory.EntityFramework,
            RuleSeverity.Warning
        ),
        new AnalysisRule(
            "EF002",
            "N+1 Query Pattern in Foreach Loop",
            "Executing database queries or lazy-loaded navigation properties inside a loop causes severe network latency.",
            RuleCategory.EntityFramework,
            RuleSeverity.Critical
        ),
        new AnalysisRule(
            "EF003",
            "Excessive / Deep .Include() Chain",
            "Query contains 3 or more .Include() / .ThenInclude() calls, which can cause massive SQL join payload overhead.",
            RuleCategory.EntityFramework,
            RuleSeverity.Warning
        ),
        new AnalysisRule(
            "EF004",
            "Synchronous DB Call in Async Method",
            "Executing synchronous EF methods like .ToList() or .FirstOrDefault() inside async methods blocks threads.",
            RuleCategory.EntityFramework,
            RuleSeverity.Warning
        ),
        new AnalysisRule(
            "EF005",
            "Cartesian Explosion Risk",
            "Including multiple collection navigation properties in a single query creates duplicate row multiplication in SQL results.",
            RuleCategory.EntityFramework,
            RuleSeverity.Critical
        ),
        new AnalysisRule(
            "EF006",
            "Client-Side Evaluation Trap",
            "Calling custom C# methods inside LINQ predicates forces EF Core to evaluate filters row-by-row on the client.",
            RuleCategory.EntityFramework,
            RuleSeverity.Critical
        )
    };
}