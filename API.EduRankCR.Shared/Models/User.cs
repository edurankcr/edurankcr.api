using System.ComponentModel.DataAnnotations;

namespace API.EduRankCR.Shared.Models
{
    public enum UserRole
    {
        User,
        Moderator,
        Administrator
    }

    public class User
    {
        // Required fields
        [Required]
        public required Guid Id { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 2, ErrorMessage = "LENGTH_NAME_INVALID")]
        public required string Name { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 2, ErrorMessage = "LENGTH_LASTNAME_INVALID")]
        public required string LastName { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 2, ErrorMessage = "LENGTH_USERNAME_INVALID")]
        [RegularExpression(
            @"^(?!.*\.\.)(?!\.)[a-zA-Z0-9._]+(?<!\.)$",
            ErrorMessage = "USERNAME_INVALID"
        )]
        public required string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "EMAIL_INVALID")]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public required DateTime BirthDate { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 6, ErrorMessage = "LENGTH_PASSWORD_INVALID")]
        public required string PasswordHash { get; set; }

        // Optional fields
        [Url(ErrorMessage = "AVATAR_URL_INVALID")]
        public string? AvatarUrl { get; set; }

        [StringLength(512, ErrorMessage = "BIOGRAPHY_LENGTH_INVALID")]
        public string? Biography { get; set; }

        // Other fields
        [Required]
        public required bool EmailVerified { get; set; } = false;

        [Required]
        public required UserRole Role { get; set; } = UserRole.User;

        // Methods
        public void SetPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Verify password
        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
    }
}
