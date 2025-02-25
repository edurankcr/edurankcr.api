using Microsoft.AspNetCore.Http;

namespace EduRankCR.Contracts.Profile;

public record ChangeAvatarRequest(IFormFile Avatar);