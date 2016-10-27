using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FitnessApp.Models;
using ApplicationModels.FitnessApp.Models;

namespace FitnessApp.Data
{
    public class FitnessAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public FitnessAppDbContext(DbContextOptions<FitnessAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<FitnessClassType> FitnessClassType { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<FitnessClass> FitnessClass { get; set; }
        public DbSet<RegistrationRecord> RegistrationRecord { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
