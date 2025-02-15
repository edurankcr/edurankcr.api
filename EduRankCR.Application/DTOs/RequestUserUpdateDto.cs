using EduRankCR.Domain.Enums;

namespace EduRankCR.Application.DTOs
{
    public class RequestUserUpdateDto
    {
        // Optional properties
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public DateTime? Birthdate { get; set; }
        public UserRole? Role { get; set; }
        public UserStatus? Status { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Biography { get; set; }
    }
}
