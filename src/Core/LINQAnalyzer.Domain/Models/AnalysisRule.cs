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
            "Materializing a query into memory before applying Where/Select filters prevents query optimization and increases heap allocations.",
            RuleCategory.LINQ,
            RuleSeverity.Critical
        ),
        new AnalysisRule(
            "EF001",
            "Missing AsNoTracking() in Read-Only Query",
            "Queries executed for read-only purposes without .AsNoTracking() incur unnecessary Entity Framework change tracking overhead.",
            RuleCategory.EntityFramework,
            RuleSeverity.Warning
        ),
        new AnalysisRule(
            "EF002",
            "N+1 Query Pattern in Foreach Loop",
            "Executing database queries or lazy-loaded navigation properties inside a loop causes severe network roundtrip latency.",
            RuleCategory.EntityFramework,
            RuleSeverity.Critical
        )
    };
}