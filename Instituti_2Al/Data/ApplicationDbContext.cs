using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Instituti_2Al.Models;


namespace Instituti_2Al.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<BaseClass> BaseClasses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Instituti_2Al.Models.Course>? Course { get; set; }
    }
}