using Microsoft.EntityFrameworkCore;

namespace Project_Api.Model
{
    public class ProjectApiDbContext: DbContext
    {
        public ProjectApiDbContext(DbContextOptions<ProjectApiDbContext> options) : base(options) { }
        public DbSet<Heroe> Heroes { get; set; }
    }
}
