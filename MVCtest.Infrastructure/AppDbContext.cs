using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCtest.Domain;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace MVCtest.Infrastructure
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);

            #region seed data

            Builder.Entity<AppUser>().HasData(SeedData.GetSeedUsers());
            Builder.Entity<IdentityRole>().HasData(SeedData.GetSeedRoles());
            Builder.Entity<IdentityUserRole<string>>().HasData(SeedData.GetSeedUserRoles());

            #endregion

            #region foreign keys

            Builder.Entity<Item>()
                .HasOne(x => x.User)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Auto-generate

            Builder.Entity<Item>().Property(p => p.Id)
                .ValueGeneratedOnAdd();

            Builder.Entity<AppUser>().Property(e => e.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region Query Filters

            Builder.Entity<Item>().HasQueryFilter(x => !x.isDeleted);

            #endregion
        }
    }
}