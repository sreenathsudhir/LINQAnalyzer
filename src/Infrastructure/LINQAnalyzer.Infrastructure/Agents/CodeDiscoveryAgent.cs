using System.IO;
using System.Threading;
using System.Threading.Tasks;
using LibGit2Sharp;
using LINQAnalyzer.Application.Interfaces;
using LINQAnalyzer.Domain.Models;

namespace LINQAnalyzer.Infrastructure.Agents;

/// <summary>
/// Agent 1: Handles dynamic repository retrieval, cloning, authentication, and directory cleanup.
/// </summary>
public class CodeDiscoveryAgent : ICodeDiscoveryAgent
{
    /// <summary>
    /// Clones a remote Git repository to an isolated temporary directory.
    /// Supports public and private repositories (via Personal Access Token).
    /// </summary>
    /// <param name="request">Scan parameters containing Git URL, Branch, and Credentials.</param>
    /// <param name="cancellationToken">Cancellation token to abort operations.</param>
    /// <returns>The local folder path where the repository was cloned.</returns>
    public Task<string> CloneRepositoryAsync(ScanRequest request, CancellationToken cancellationToken = default)
    {
        // Generate an isolated temporary directory name based on the Scan ID
        string tempDirectory = Path.Combine(Path.GetTempPath(), "LINQScan_" + request.Id.ToString("N"));

        var cloneOptions = new CloneOptions
        {
            BranchName = string.IsNullOrWhiteSpace(request.Branch) ? "main" : request.Branch,
            RecurseSubmodules = false
        };

        // If a Personal Access Token (PAT) is provided, set up HTTPS credentials
        if (!string.IsNullOrWhiteSpace(request.PersonalAccessToken))
        {
            cloneOptions.FetchOptions.CredentialsProvider = (_url, _user, _cred) =>
                new UsernamePasswordCredentials
                {
                    Username = "token", // Standard username used for Git PAT authentication
                    Password = request.PersonalAccessToken
                };
        }

        // Perform the clone operation on a background thread
        return Task.Run(() =>
        {
            cancellationToken.ThrowIfCancellationRequested();
            Repository.Clone(request.GitUrl, tempDirectory, cloneOptions);
            return tempDirectory;
        }, cancellationToken);
    }

    /// <summary>
    /// Cleans up temporary clone directories and overrides read-only Git file permissions on OS filesystem.
    /// </summary>
    /// <param name="localPath">The local path to delete.</param>
    public void CleanupRepository(string localPath)
    {
        if (Directory.Exists(localPath))
        {
            // Remove read-only attributes from Git internal files (.git folder) to prevent AccessDenied exceptions
            foreach (var file in Directory.GetFiles(localPath, "*", SearchOption.AllDirectories))
            {
                File.SetAttributes(file, FileAttributes.Normal);
            }
            Directory.Delete(localPath, true);
        }
    }
}