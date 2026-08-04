namespace LINQAnalyzer.Domain.Models;

/// <summary>
/// Data model representing user input parameters for a code scan job.
/// </summary>
public class ScanRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string GitUrl { get; set; } = string.Empty;
    public string Branch { get; set; } = "main";
    public string? PersonalAccessToken { get; set; }
    public string? TargetFolderPath { get; set; }
    public List<string> SelectedRuleIds { get; set; } = new();
    
    /// <summary>
    /// Set to 0 for dynamic evaluation (analyzes 100% of discovered issues).
    /// </summary>
    public int MaxAiEvaluations { get; set; } = 0;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}