﻿using System;
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

        // this is how you add a model to the database
        public DbSet<ClothingType> ClothingTypes { get; set; }

        public DbSet <Size> Sizes { get; set; }
        public DbSet<Design> Designs { get; set; }

        public DbSet<OrderHistory> orderHistories { get; set; }

        public DbSet<OrderItemHistory> orderItemHistories { get; set; }

        public DbSet<Review> Reviews { get; set; }

        // SCROLL DOWN TO SEE EXAMPLE OF HOW TO SEED DATABASE
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

            //  THIS IS HOW YOU SEED DATABASE. THIS IS FOR CLOTHINGTYPE SEED.
            // IF YOU NEED TO SEED DATABASE USE THIS FORMAT
            // PLEASE BE MINDFUL TO ADD ALL ATTRIBUTES FOR A ROW 
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
            // SEED SIZE TABLE WITH SIZES

            builder.Entity<Size>().HasData(

                new Size
                {
                    SizeId = 1,
                    SizeName = "XS"
                },
                new Size
                {
                    SizeId = 2,
                    SizeName = "S"
                },
                new Size
                {
                    SizeId = 3,
                    SizeName = "M"
                },
                new Size
                {
                    SizeId = 4,
                    SizeName = "L"
                },
                new Size
                {
                    SizeId = 5,
                    SizeName = "XL"
                },
                new Size
                {
                    SizeId = 6,
                    SizeName = "XXL"
                }

                );
        }
    }
}
