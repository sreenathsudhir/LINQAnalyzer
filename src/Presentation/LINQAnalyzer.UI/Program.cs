using LINQAnalyzer.Application.Interfaces;
using LINQAnalyzer.Infrastructure.Agents;
using LINQAnalyzer.Infrastructure.Services;
using LINQAnalyzer.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add Blazor server components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// -----------------------------------------------------------------------------
// Core Engine & Agent Registrations (Day 1 Pipeline)
// -----------------------------------------------------------------------------

// Agent 1: Code Discovery (Git Cloner)
builder.Services.AddScoped<ICodeDiscoveryAgent, CodeDiscoveryAgent>();

// Agent 2: Performance Analyzer (Roslyn AST Engine)
builder.Services.AddScoped<IPerformanceAnalysisAgent, PerformanceAnalysisAgent>();

// Agent 3: AI Review Agent (Configured to talk to QBurst Gateway)
builder.Services.AddHttpClient<IAiReviewAgent, AiReviewAgent>(client =>
{
    // Retrieve base URL from appsettings or default to localhost / gateway mock
    var gatewayUrl = builder.Configuration["QBurstGateway:BaseUrl"] ?? "http://localhost:5000/";
    client.BaseAddress = new Uri(gatewayUrl);
    client.Timeout = TimeSpan.FromSeconds(60);
});

// Agent 6: Documentation Agent (Report Generator)
builder.Services.AddScoped<IDocumentationAgent, DocumentationAgent>();

// Pipeline Orchestrator Service
builder.Services.AddScoped<ScanOrchestratorService>();

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