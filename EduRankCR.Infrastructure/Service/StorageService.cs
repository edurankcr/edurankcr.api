﻿using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using EduRankCR.Domain.Common.Interfaces.Services;
using EduRankCR.Infrastructure.Configuration;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace EduRankCR.Infrastructure.Service;

public class StorageService : IStorageService
{
    private readonly StorageSettings _storageSettings;
    private readonly BlobServiceClient _blobServiceClient;

    public StorageService(IOptions<StorageSettings> storageSettings)
    {
        _storageSettings = storageSettings.Value;
        _blobServiceClient = new BlobServiceClient(_storageSettings.ConnectionString);
    }

    public async Task<string?> AvatarUpload(IFormFile file, string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_storageSettings.AvatarContainer);

        var blobClient = containerClient.GetBlobClient(fileName);

        await using (var stream = file.OpenReadStream())
        {
            var blobHttpHeader = new BlobHttpHeaders { ContentType = file.ContentType };
            await blobClient.UploadAsync(stream, new BlobUploadOptions { HttpHeaders = blobHttpHeader });
        }

        return blobClient.Uri.ToString();
    }
}