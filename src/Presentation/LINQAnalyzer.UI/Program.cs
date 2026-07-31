using LINQAnalyzer.Application.Interfaces;
using LINQAnalyzer.Infrastructure.Agents;
using LINQAnalyzer.Infrastructure.Services;
using LINQAnalyzer.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add Blazor server components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// -----------------------------------------------------------------------------
// Core Engine & Agent Registrations
// -----------------------------------------------------------------------------

// Agent 1: Code Discovery
builder.Services.AddScoped<ICodeDiscoveryAgent, CodeDiscoveryAgent>();

// Agent 2: Performance Analyzer (Roslyn AST Engine)
builder.Services.AddScoped<IPerformanceAnalysisAgent, PerformanceAnalysisAgent>();

// Agent 3: AI Review Agent (QBurst Gateway)
builder.Services.AddHttpClient<IAiReviewAgent, AiReviewAgent>(client =>
{
    var gatewayUrl = builder.Configuration["QBurstGateway:BaseUrl"] ?? "http://localhost:5000/";
    client.BaseAddress = new Uri(gatewayUrl);
    client.Timeout = TimeSpan.FromSeconds(60);
});

// Agent 4: Documentation Agent
builder.Services.AddScoped<IDocumentationAgent, DocumentationAgent>();

// Agent 5: PDF Export Agent
builder.Services.AddScoped<IPdfExportAgent, PdfExportAgent>();

// Agent 6: Benchmark Agent
builder.Services.AddScoped<IBenchmarkAgent, BenchmarkAgent>();

// Pipeline Orchestrator
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