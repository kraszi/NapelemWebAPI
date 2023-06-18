using Microsoft.EntityFrameworkCore;

namespace WebUj.Models
{
    public class APIDbContext:DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options) { 
        
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Project> Projets { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<ComponentsToProject> ComponentsToProjects { get; set; }
    }
}
