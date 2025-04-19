using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Infrastructure.Configuration;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace EduRankCR.Infrastructure.Services;

public class StorageService : IStorageService
{
    private readonly StorageSettings _storageSettings;
    private readonly BlobServiceClient _blobServiceClient;

    public StorageService(IOptions<StorageSettings> storageOptions)
    {
        var settings = storageOptions.Value;

        _storageSettings = new StorageSettings
        {
            ConnectionString = Environment.GetEnvironmentVariable("storage-connection-string") ?? settings.ConnectionString,
            AvatarContainer = Environment.GetEnvironmentVariable("storage-avatar-container") ?? settings.AvatarContainer,
        };

        _blobServiceClient = new BlobServiceClient(_storageSettings.ConnectionString);
    }

    public async Task<string?> AvatarUpload(IFormFile file, string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_storageSettings.AvatarContainer);
        var blobClient = containerClient.GetBlobClient(fileName);

        await using var stream = file.OpenReadStream();
        var blobHttpHeader = new BlobHttpHeaders { ContentType = file.ContentType };

        await blobClient.UploadAsync(stream, new BlobUploadOptions
        {
            HttpHeaders = blobHttpHeader,
        });

        return blobClient.Uri.ToString();
    }

    public async Task DeleteAvatar(string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_storageSettings.AvatarContainer);
        var blobClient = containerClient.GetBlobClient(fileName);

        await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
    }
}