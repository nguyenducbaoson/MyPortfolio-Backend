using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Entities.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Experience> Experience { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
