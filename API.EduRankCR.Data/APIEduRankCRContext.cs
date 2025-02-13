using Microsoft.EntityFrameworkCore;
using API.EduRankCR.Shared.Models;
using API.EduRankCR.Shared.DTOs;

namespace API.EduRankCR.Data
{
    public class APIEduRankCRContext : DbContext
    {
        public APIEduRankCRContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        // Responses
        public DbSet<NewUserResponseDTO> NewUserResult { get; set; }
    }
}
