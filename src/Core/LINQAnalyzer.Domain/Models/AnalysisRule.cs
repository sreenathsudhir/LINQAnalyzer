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
        // --- Core Rules (LINQ001 - EF005) ---
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
            "Multiple Enumeration / Unfiltered Query",
            "Filtering via .Where() occurs after materializing data into memory (.ToList/.AsEnumerable), downloading unnecessary rows.",
            RuleCategory.Memory,
            RuleSeverity.Critical
        ),
        new AnalysisRule(
            "LINQ005",
            "Repeated LINQ Evaluation in Loop Condition",
            "LINQ expressions evaluated inside for/while loop condition headers execute repeatedly on every loop iteration.",
            RuleCategory.LINQ,
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
            "Query contains multiple .Include() / .ThenInclude() calls, which can cause massive SQL join payload overhead.",
            RuleCategory.EntityFramework,
            RuleSeverity.Critical
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
            "Client-Side Evaluation Trap",
            "Calling custom C# methods inside LINQ predicates forces EF Core to evaluate filters row-by-row on the client.",
            RuleCategory.EntityFramework,
            RuleSeverity.Critical
        ),

        // --- Expanded Enterprise Rules (EF006 - LINQ012) ---
        new AnalysisRule(
            "EF006",
            "Missing CancellationToken in Async Query",
            "Async EF Core database queries executed without passing a CancellationToken leave orphan queries running on database server after client disconnects.",
            RuleCategory.EntityFramework,
            RuleSeverity.Critical
        ),
        new AnalysisRule(
            "EF007",
            "Iterative SaveChanges() in Loop",
            "Invoking DbContext.SaveChanges() or SaveChangesAsync() inside loops creates thousands of separate database transactions.",
            RuleCategory.EntityFramework,
            RuleSeverity.Critical
        ),
        new AnalysisRule(
            "EF008",
            "Row-by-Row Updates / Deletes",
            "Fetching entities into local memory to modify or delete them individually instead of leveraging EF Core bulk APIs.",
            RuleCategory.EntityFramework,
            RuleSeverity.Critical
        ),
        new AnalysisRule(
            "LINQ006",
            "Implicit IEnumerable Casting Before Filter",
            "Casting IQueryable to IEnumerable or calling AsEnumerable() before .Where() forces full table data download prior to client filtering.",
            RuleCategory.LINQ,
            RuleSeverity.Warning
        ),
        new AnalysisRule(
            "LINQ007",
            "Redundant OrderBy Before Aggregation",
            "Calling .OrderBy() before scalar operations like .Count(), .Any(), or .Sum() adds unnecessary SQL sorting overhead.",
            RuleCategory.LINQ,
            RuleSeverity.Warning
        ),
        new AnalysisRule(
            "LINQ008",
            "In-Memory Sorting After Materialization",
            "Calling .ToList() prior to .OrderBy() forces sorting to execute in C# RAM rather than leveraging SQL indexes.",
            RuleCategory.Memory,
            RuleSeverity.Warning
        ),
        new AnalysisRule(
            "EF009",
            "Hardcoded DbContext Instantiation",
            "Instantiating DbContext via new operator bypasses Dependency Injection lifetime management and connection pooling.",
            RuleCategory.EntityFramework,
            RuleSeverity.Info
        ),
        new AnalysisRule(
            "EF010",
            "Missing Query Tagging (TagWith)",
            "Complex EF Core queries missing .TagWith() annotations make SQL profiling and telemetry tracing difficult.",
            RuleCategory.EntityFramework,
            RuleSeverity.Info
        ),
        new AnalysisRule(
            "LINQ009",
            "Index-Breaking String Mutation in Filter",
            "Wrapping column names in string methods like .ToLower() inside .Where() prevents SQL engine from utilizing column indexes.",
            RuleCategory.LINQ,
            RuleSeverity.Warning
        ),
        new AnalysisRule(
            "LINQ010",
            "String Concatenation in Predicate",
            "Concatenating strings inside LINQ predicates prevents SQL parameterization and causes execution plan cache thrashing.",
            RuleCategory.LINQ,
            RuleSeverity.Warning
        ),
        new AnalysisRule(
            "LINQ011",
            "Redundant Distinct() After GroupBy",
            "Applying .Distinct() immediately after a .GroupBy() operation is redundant and adds extra grouping/sorting passes.",
            RuleCategory.LINQ,
            RuleSeverity.Warning
        ),
        new AnalysisRule(
            "LINQ012",
            "Unbounded Data Fetch (Missing Take/Pagination)",
            "Executing queries without .Take() or explicit pagination risks fetching millions of records into heap memory.",
            RuleCategory.Memory,
            RuleSeverity.Critical
        )
    };
}