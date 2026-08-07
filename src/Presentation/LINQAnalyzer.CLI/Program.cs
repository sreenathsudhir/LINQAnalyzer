using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotNetEnv;
using LINQAnalyzer.Application.Interfaces;
using LINQAnalyzer.Domain.Models;
using LINQAnalyzer.Infrastructure.Agents;
using LINQAnalyzer.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LINQAnalyzer.CLI;

class Program
{
    static async Task<int> Main(string[] args)
    {
        // Load .env and overwrite existing process environment variables
        string envPath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
        if (File.Exists(envPath))
        {
            Env.Load(envPath, new LoadOptions(clobberExistingVars: true));
        }
        else
        {
            Env.Load();
        }

        Console.WriteLine("==================================================");
        Console.WriteLine("🚀 LINQ & EF Core Performance Analyzer CLI");
        Console.WriteLine("==================================================\n");

        string repoUrl = GetArgument(args, "--repo") ?? GetArgument(args, "-r") ?? string.Empty;
        string branch = GetArgument(args, "--branch") ?? GetArgument(args, "-b") ?? "main";
        string outputDir = GetArgument(args, "--output") ?? GetArgument(args, "-o") ?? "./reports";
        string? pat = GetArgument(args, "--pat");

        if (string.IsNullOrWhiteSpace(repoUrl))
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("  dotnet run --project src/Presentation/LINQAnalyzer.CLI -- --repo <git-url> [--branch <branch>] [--output <path>] [--pat <token>]\n");
            Console.WriteLine("Example:");
            Console.WriteLine("  dotnet run --project src/Presentation/LINQAnalyzer.CLI -- -r https://github.com/dotnet/eShop.git -b main -o ./output");
            return 1;
        }

        // Build Configuration Container from Generic Environment Variables with Fallbacks
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                { 
                    "LlmSettings:ApiKey", 
                    Environment.GetEnvironmentVariable("LLM_API_KEY") 
                    ?? Environment.GetEnvironmentVariable("LlmSettings__ApiKey") 
                    ?? Environment.GetEnvironmentVariable("GROQ_API_KEY") 
                },
                { 
                    "LlmSettings:BaseUrl", 
                    Environment.GetEnvironmentVariable("LLM_BASE_URL") 
                    ?? Environment.GetEnvironmentVariable("LlmSettings__BaseUrl") 
                },
                { 
                    "LlmSettings:Model", 
                    Environment.GetEnvironmentVariable("LLM_MODEL") 
                    ?? Environment.GetEnvironmentVariable("LlmSettings__Model") 
                }
            })
            .Build();

        // Setup Dependency Injection Container
        var services = new ServiceCollection();
        services.AddSingleton<IConfiguration>(configuration);

        // Agent 1: Code Discovery
        services.AddScoped<ICodeDiscoveryAgent, CodeDiscoveryAgent>();

        // Agent 2: Performance Analyzer
        services.AddScoped<IPerformanceAnalysisAgent, PerformanceAnalysisAgent>();

        // Agent 3: AI Review Agent
        services.AddHttpClient<IAiReviewAgent, AiPerformanceReviewAgent>(client =>
        {
            client.Timeout = TimeSpan.FromSeconds(60);
        });

        // Agent 4: Documentation Agent
        services.AddScoped<IDocumentationAgent, DocumentationAgent>();

        // Agent 5: PDF Export Agent
        services.AddScoped<IPdfExportAgent, PdfExportAgent>();

        // Agent 6: Benchmark Agent
        services.AddScoped<IBenchmarkAgent, BenchmarkAgent>();

        // Pipeline Orchestrator
        services.AddScoped<ScanOrchestratorService>();

        var provider = services.BuildServiceProvider();
        var orchestrator = provider.GetRequiredService<ScanOrchestratorService>();
        var docAgent = provider.GetRequiredService<IDocumentationAgent>();
        var pdfAgent = provider.GetRequiredService<IPdfExportAgent>();

        var request = new ScanRequest
        {
            GitUrl = repoUrl,
            Branch = branch,
            PersonalAccessToken = pat,
            SelectedRuleIds = RuleRegistry.AvailableRules.Select(r => r.Id).ToList()
        };

        Console.WriteLine($"🔍 Target Repository : {repoUrl}");
        Console.WriteLine($"🌿 Target Branch     : {branch}");
        Console.WriteLine($"🛡️ Active Rules      : {request.SelectedRuleIds.Count}\n");

        List<DiscoveredIssue> discoveredIssues = new();
        (List<DiscoveredIssue> Issues, string HtmlReport) scanResult;

        try
        {
            scanResult = await orchestrator.ExecuteScanAsync(request, progress =>
            {
                Console.WriteLine($"[{progress.PercentComplete,3}%] {progress.Stage}: {progress.Message}");
                if (progress.LatestIssue != null && !discoveredIssues.Any(i => i.RuleId == progress.LatestIssue.RuleId && i.FilePath == progress.LatestIssue.FilePath && i.LineNumber == progress.LatestIssue.LineNumber))
                {
                    discoveredIssues.Add(progress.LatestIssue);
                }
            });
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ Scan failed: {ex.Message}");
            Console.ResetColor();
            return 1;
        }

        // Write outputs
        Directory.CreateDirectory(outputDir);

        string htmlPath = Path.Combine(outputDir, "report.html");
        await File.WriteAllTextAsync(htmlPath, scanResult.HtmlReport);

        string mdPath = Path.Combine(outputDir, "report.md");
        string markdownContent = await docAgent.GenerateMarkdownReportAsync(request, scanResult.Issues);
        await File.WriteAllTextAsync(mdPath, markdownContent);

        string pdfPath = Path.Combine(outputDir, "report.pdf");
        byte[] pdfBytes = pdfAgent.GeneratePdfReport(request, scanResult.Issues);
        await File.WriteAllBytesAsync(pdfPath, pdfBytes);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✅ Scan Complete!");
        Console.ResetColor();
        Console.WriteLine($"📊 Discovered Issues: {scanResult.Issues.Count}");
        Console.WriteLine($"📁 Reports saved to : {Path.GetFullPath(outputDir)}");
        Console.WriteLine($"   ├── report.html");
        Console.WriteLine($"   ├── report.md");
        Console.WriteLine($"   └── report.pdf\n");

        return 0;
    }

    private static string? GetArgument(string[] args, string flag)
    {
        for (int i = 0; i < args.Length - 1; i++)
        {
            if (args[i].Equals(flag, StringComparison.OrdinalIgnoreCase))
            {
                return args[i + 1];
            }
        }
        return null;
    }
}