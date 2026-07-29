using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public Task<string> CloneRepositoryAsync(ScanRequest request, CancellationToken cancellationToken = default)
    {
        string tempDirectory = Path.Combine(Path.GetTempPath(), "LINQScan_" + request.Id.ToString("N"));

        var cloneOptions = new CloneOptions
        {
            BranchName = string.IsNullOrWhiteSpace(request.Branch) ? "main" : request.Branch,
            FetchOptions =
            {
                CredentialsProvider = (_url, _userFromUrl, _types) =>
                {
                    if (!string.IsNullOrWhiteSpace(request.PersonalAccessToken))
                    {
                        return new UsernamePasswordCredentials
                        {
                            Username = "token",
                            Password = request.PersonalAccessToken
                        };
                    }
                    return null;
                }
            }
        };

        return Task.Run(() =>
        {
            cancellationToken.ThrowIfCancellationRequested();
            Repository.Clone(request.GitUrl, tempDirectory, cloneOptions);
            return tempDirectory;
        }, cancellationToken);
    }

    /// <summary>
    /// Fetches all remote branch names without cloning full repository source files.
    /// </summary>
    public Task<List<string>> GetRemoteBranchesAsync(string gitUrl, string? personalAccessToken = null, CancellationToken cancellationToken = default)
    {
        return Task.Run(() =>
        {
            cancellationToken.ThrowIfCancellationRequested();

            var remoteRefs = Repository.ListRemoteReferences(
                gitUrl,
                (_url, _userFromUrl, _types) =>
                {
                    if (!string.IsNullOrWhiteSpace(personalAccessToken))
                    {
                        return new UsernamePasswordCredentials
                        {
                            Username = "token",
                            Password = personalAccessToken
                        };
                    }
                    return null;
                },
                null
            );

            var branches = remoteRefs
                .Where(r => !r.IsTag && r.CanonicalName.StartsWith("refs/heads/"))
                .Select(r => r.CanonicalName.Replace("refs/heads/", ""))
                .Distinct()
                .OrderBy(b => b)
                .ToList();

            return branches;
        }, cancellationToken);
    }

    public void CleanupRepository(string localPath)
    {
        if (Directory.Exists(localPath))
        {
            foreach (var file in Directory.GetFiles(localPath, "*", SearchOption.AllDirectories))
            {
                File.SetAttributes(file, FileAttributes.Normal);
            }
            Directory.Delete(localPath, true);
        }
    }
}