using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;

namespace RealEstate.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Plans> Plans { get; set; }
        public DbSet<Amenties> Amenties { get; set; }
#if false
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<SubSpecification> SubSpecifications { get; set; }
        public DbSet<LocationHighlight> LocationHighlights { get; set; }
        public DbSet<SubLocationHighlight> SubLocationHighlights { get; set; }
#endif
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Amenties image column to support large Base64 strings
            modelBuilder.Entity<Amenties>()
                .Property(a => a.AmentiesImage)
                .HasColumnType("nvarchar(max)");

            // Configure Plans image column to support large Base64 strings
            modelBuilder.Entity<Plans>()
                .Property(p => p.PlanImage)
                .HasColumnType("nvarchar(max)");

            // Configure Project columns to support large Base64 strings and text
            modelBuilder.Entity<Project>()
                .Property(p => p.Logo)
                .HasColumnType("nvarchar(max)");
            modelBuilder.Entity<Project>()
                .Property(p => p.BannerImage)
                .HasColumnType("nvarchar(max)");
            modelBuilder.Entity<Project>()
                .Property(p => p.OverviewImage)
                .HasColumnType("nvarchar(max)");
            modelBuilder.Entity<Project>()
                .Property(p => p.Description)
                .HasColumnType("nvarchar(max)");
            modelBuilder.Entity<Project>()
                .Property(p => p.MasterDescription)
                .HasColumnType("nvarchar(max)");
            modelBuilder.Entity<Project>()
                .Property(p => p.AmentiesDescription)
                .HasColumnType("nvarchar(max)");
            modelBuilder.Entity<Project>()
                .Property(p => p.OtherDetails)
                .HasColumnType("nvarchar(max)");
            modelBuilder.Entity<Project>()
                .Property(p => p.Youtube)
                .HasColumnType("nvarchar(max)");
            modelBuilder.Entity<Project>()
                .Property(p => p.SpecificationsTitle)
                .HasColumnType("nvarchar(max)");
            modelBuilder.Entity<Project>()
                .Property(p => p.SpecificationsDescription)
                .HasColumnType("nvarchar(max)");
            modelBuilder.Entity<Project>()
                .Property(p => p.LocationHighlightsTitle)
                .HasColumnType("nvarchar(max)");
            modelBuilder.Entity<Project>()
                .Property(p => p.LocationHighlightsDescription)
                .HasColumnType("nvarchar(max)");

            // Configure Relationships
#if false
            modelBuilder.Entity<SubSpecification>()
                .HasOne(s => s.Specification)
                .WithMany(s => s.SubSpecifications)
                .HasForeignKey(s => s.SpecificationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SubLocationHighlight>()
                .HasOne(s => s.LocationHighlight)
                .WithMany(l => l.SubLocationHighlights)
                .HasForeignKey(s => s.LocationHighlightId)
                .OnDelete(DeleteBehavior.Cascade);
#endif

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
