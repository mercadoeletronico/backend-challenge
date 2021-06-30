using BackendChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Infrastructure.Data
{
    public class BackendChallengeDbContext : DbContext
    {
        public BackendChallengeDbContext(DbContextOptions<BackendChallengeDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
