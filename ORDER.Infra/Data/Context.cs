using Microsoft.EntityFrameworkCore;

namespace ORDER.Infra.Data
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> builderOptions) : base(builderOptions)
        {
        }
        
        
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
            // optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=myp;Password=batata123;Database=me-project;");
        // }
    }
}