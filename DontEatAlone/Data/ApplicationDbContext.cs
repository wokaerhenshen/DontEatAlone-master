﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DontEatAlone.Models;

namespace DontEatAlone.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasOne(ur => ur.User)
                .WithOne(au => au.ApplicationUser)
                .HasForeignKey<User>(ur => ur.Id);

            builder.Entity<User>()
                .HasOne(ps => ps.PremiumSubscription)
                .WithOne(ur => ur.User)
                .HasForeignKey<PremiumSubscription>(ps => ps.ID);

            builder.Entity<UserReservation>()
                .HasKey(ur => new { ur.userID, ur.reservationID });

            builder.Entity<UserReservation>()
                .HasOne(u => u.User)
                .WithMany(ur => ur.UserReservations)
                .HasForeignKey(fk => new { fk.userID })
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserReservation>()
                .HasOne(u => u.Reservation)
                .WithMany(ur => ur.UserReservations)
                .HasForeignKey(fk => new { fk.reservationID })
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Reservation>()
                .HasOne(lm => lm.Limitations)
                .WithOne(rv => rv.Reservation)
                .HasForeignKey<Limitations>(lm => lm.id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(rv => rv.Reservation)
                .WithMany(cm => cm.Comments)
                .HasForeignKey(fk => new { fk.reservationID })
                .OnDelete(DeleteBehavior.Restrict);



            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
