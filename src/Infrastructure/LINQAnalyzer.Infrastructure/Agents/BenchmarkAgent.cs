using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LINQAnalyzer.Application.Interfaces;

namespace LINQAnalyzer.Infrastructure.Agents;

public class BenchmarkAgent : IBenchmarkAgent
{
    public Task<BenchmarkResult> BenchmarkSnippetAsync(string codeSnippet)
    {
        var sw = Stopwatch.StartNew();
        long initialMemory = GC.GetAllocatedBytesForCurrentThread();

        // Analyze query patterns to estimate allocation and execution impact
        bool hasToListInLoop = codeSnippet.Contains(".ToList()") || codeSnippet.Contains(".ToArray()");
        bool hasSelectAll = codeSnippet.Contains("Select(x => x)") || !codeSnippet.Contains("Select(");
        bool hasCartesianJoin = codeSnippet.Contains("SelectMany") || codeSnippet.Contains("from") && codeSnippet.Split("from").Length > 2;

        long estimatedBytes = 1024; // Baseline overhead
        if (hasToListInLoop) estimatedBytes += 524_288; // ~500 KB estimated for in-memory materialize
        if (hasSelectAll) estimatedBytes += 131_072;     // ~128 KB extra columns overhead
        if (hasCartesianJoin) estimatedBytes += 2_097_152; // ~2 MB potential N+1 / join multiplier

        sw.Stop();
        
        // Mock SQL translation output based on query structure
        string simulatedSql = GenerateSimulatedSql(codeSnippet);
        double executionTimeMs = Math.Round(sw.Elapsed.TotalMilliseconds + (estimatedBytes / 50_000.0), 2);

        return Task.FromResult(new BenchmarkResult(
            EstimatedAllocatedBytes: estimatedBytes,
            ExecutionTimeMs: executionTimeMs,
            ExecutedSql: simulatedSql
        ));
    }

    private static string GenerateSimulatedSql(string snippet)
    {
        if (snippet.Contains("Count() > 0") || snippet.Contains("Count() != 0"))
        {
            return "-- Anti-Pattern Detected: COUNT(*) fetches full result set\nSELECT COUNT(*)\nFROM [Entities] AS [e]";
        }
        if (snippet.Contains(".Where("))
        {
            return "SELECT [e].[Id], [e].[Name], [e].[CreatedDate]\nFROM [Entities] AS [e]\nWHERE [e].[IsActive] = 1";
        }
        return "SELECT [e].[Id], [e].[ColumnA], [e].[ColumnB]\nFROM [Entities] AS [e]";
    }
}