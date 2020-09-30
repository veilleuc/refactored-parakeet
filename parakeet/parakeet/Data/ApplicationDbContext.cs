using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using parakeet.Models;

namespace parakeet.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClothingType> ClothingTypes { get; set; }
        public DbSet<Design> Designs { get; set; }

        public DbSet<OrderHistory> orderHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            builder.Entity<ClothingType>().HasData(
        new ClothingType
        {
            ClothingTypeId = 1,
            type = "Short Sleeve Shirt",
            price = 20.0f
        },
        new ClothingType
        {
            ClothingTypeId = 2,
            type = "Long Sleeve Shirt",
            price = 35.0f
        },
        new ClothingType
        {
            ClothingTypeId = 3,
            type = "Jacket",
            price = 50.0f
        },
        new ClothingType
        {
            ClothingTypeId = 4,
            type = "Hoodie",
            price = 40.0f
        }
    ) ;
        }
    }
}
