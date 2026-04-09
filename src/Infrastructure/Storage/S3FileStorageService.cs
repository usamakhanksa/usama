using Application.Common;

namespace Infrastructure.Storage;

public class S3FileStorageService : IFileStorageService
{
    public Task<string> UploadAsync(Stream stream, string path, string contentType, CancellationToken cancellationToken = default)
        => Task.FromResult(path);

    public Task DeleteAsync(string path, CancellationToken cancellationToken = default)
        => Task.CompletedTask;

    public string GetUrl(string path, TimeSpan? ttl = null)
        => $"https://storage.example.com/{path}";
}
