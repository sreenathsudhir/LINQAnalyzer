using System.Threading.Tasks;
using LINQAnalyzer.Domain.Models;

namespace LINQAnalyzer.Application.Interfaces;

public record BenchmarkResult(
    long EstimatedAllocatedBytes,
    double ExecutionTimeMs,
    string ExecutedSql
);

public interface IBenchmarkAgent
{
    Task<BenchmarkResult> BenchmarkSnippetAsync(string codeSnippet);
}