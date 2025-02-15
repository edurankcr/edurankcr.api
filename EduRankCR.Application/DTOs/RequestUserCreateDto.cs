using EduRankCR.Domain.Enums;

namespace EduRankCR.Application.DTOs
{
    public class RequestUserCreateDto
    {
        // Required properties
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; } = false;
        public DateTime Birthdate { get; set; } = DateTime.MinValue;
        public string Password { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.User;
        
        // Optional properties
        public string? AvatarUrl { get; set; }
        public string? Biography { get; set; }
    }
}
