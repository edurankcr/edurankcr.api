using System.ComponentModel.DataAnnotations;

namespace API.EduRankCR.Shared.DTOs
{
    public class NewUserRequestDTO
    {
        // Required fields
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
        public required string Password { get; set; }
    }

    public class NewUserResponseDTO
    {
        public Guid Id { get; set; }
    }
}
