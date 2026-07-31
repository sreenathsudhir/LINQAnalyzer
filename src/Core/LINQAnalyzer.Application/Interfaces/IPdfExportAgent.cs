using LINQAnalyzer.Domain.Models;

namespace LINQAnalyzer.Application.Interfaces;

public interface IPdfExportAgent
{
    byte[] GeneratePdfReport(ScanRequest request, List<DiscoveredIssue> issues);
}