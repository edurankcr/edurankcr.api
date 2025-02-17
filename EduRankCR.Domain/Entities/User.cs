﻿using EduRankCR.Domain.Enums;

namespace EduRankCR.Domain.Entities
{
    public class User : MainUserId
    {
        // Required properties
        public required string Name { get; set; } = string.Empty;
        public required string LastName { get; set; } = string.Empty;
        public required string Username { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public required bool EmailConfirmed { get; set; } = false;
        public required DateTime Birthdate { get; set; }
        public required string Password { get; set; } = string.Empty;
        public required UserRole Role { get; set; } = UserRole.User;
        public required UserStatus Status { get; set; } = UserStatus.Active;
        
        // Optional properties
        public string? NewEmail { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Biography { get; set; }
        
        // Additional properties
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}