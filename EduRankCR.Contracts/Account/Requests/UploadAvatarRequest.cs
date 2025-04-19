using Microsoft.AspNetCore.Http;

namespace EduRankCR.Contracts.Account.Requests;

public sealed record UploadAvatarRequest(IFormFile File);