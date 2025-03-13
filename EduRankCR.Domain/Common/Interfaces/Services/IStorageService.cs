using Microsoft.AspNetCore.Http;

namespace EduRankCR.Domain.Common.Interfaces.Services;

public interface IStorageService
{
    Task<string?> AvatarUpload(IFormFile file, string fileName);
}