using EduRankCR.Domain.Enums;

namespace EduRankCR.Application.DTOs
{
    public class UserUpdateDto
    {
        // Required properties
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public DateTime? Birthdate { get; set; } = null;
        public UserRole? Role { get; set; }
        public UserStatus? Status { get; set; }
        
        // Optional properties
        public string? AvatarUrl { get; set; }
        public string? Biography { get; set; }
    }
}
