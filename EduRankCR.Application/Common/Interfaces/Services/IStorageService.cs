using Microsoft.AspNetCore.Http;

namespace EduRankCR.Application.Common.Interfaces.Services;

public interface IStorageService
{
    Task<string?> AvatarUpload(IFormFile file, string fileName);
}