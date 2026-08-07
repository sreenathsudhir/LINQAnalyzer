using System;
using System.Collections.Generic;
using System.IO;
using DotNetEnv;
using LINQAnalyzer.Application.Interfaces;
using LINQAnalyzer.Infrastructure.Agents;
using LINQAnalyzer.Infrastructure.Services;
using LINQAnalyzer.UI.Components;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// -----------------------------------------------------------------------------
// 1. Locate and Load Root .env File via Directory Traversal
// -----------------------------------------------------------------------------
string currentDir = Directory.GetCurrentDirectory();
string? envPath = null;

while (!string.IsNullOrEmpty(currentDir))
{
    string testPath = Path.Combine(currentDir, ".env");
    if (File.Exists(testPath))
    {
        envPath = testPath;
        break;
    }
    currentDir = Directory.GetParent(currentDir)?.FullName!;
}

if (!string.IsNullOrEmpty(envPath))
{
    Env.Load(envPath, new LoadOptions(clobberExistingVars: true));
    Console.WriteLine($"[Config] ✅ Loaded .env from: {envPath}");
}
else
{
    Console.WriteLine("[Config] ⚠️ Warning: .env file not found in directory tree.");
}

var builder = WebApplication.CreateBuilder(args);

// -----------------------------------------------------------------------------
// 2. Map Generic LLM Environment Variables to Configuration
// -----------------------------------------------------------------------------
builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
{
    { 
        "LlmSettings:ApiKey", 
        Environment.GetEnvironmentVariable("LLM_API_KEY") 
        ?? Environment.GetEnvironmentVariable("LlmSettings__ApiKey") 
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
});

// -----------------------------------------------------------------------------
// 3. UI & Core Services Registration
// -----------------------------------------------------------------------------
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Agent Registrations
builder.Services.AddScoped<ICodeDiscoveryAgent, CodeDiscoveryAgent>();
builder.Services.AddScoped<IPerformanceAnalysisAgent, PerformanceAnalysisAgent>();

builder.Services.AddHttpClient<IAiReviewAgent, AiPerformanceReviewAgent>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(60);
});

builder.Services.AddScoped<IDocumentationAgent, DocumentationAgent>();
builder.Services.AddScoped<IPdfExportAgent, PdfExportAgent>();
builder.Services.AddScoped<IBenchmarkAgent, BenchmarkAgent>();

// Pipeline Orchestrator
builder.Services.AddScoped<ScanOrchestratorService>();

// -----------------------------------------------------------------------------
// 4. HTTP Pipeline Configuration
// -----------------------------------------------------------------------------
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();