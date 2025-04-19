using Microsoft.AspNetCore.Http;

namespace EduRankCR.Application.Common.Interfaces;

public interface IStorageService
{
    Task<string?> AvatarUpload(IFormFile file, string fileName);
    Task DeleteAvatar(string fileName);
}