using Microsoft.AspNetCore.Http;

namespace EduRankCR.Contracts.Account;

public sealed record UploadAvatarRequest(IFormFile File);