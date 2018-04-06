using System;
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
                .HasForeignKey<PremiumSubscription>(ps => ps.Id);

            builder.Entity<UserReservation>()
                .HasKey(ur => new { ur.UserID, ur.ReservationID });

            builder.Entity<UserReservation>()
                .HasOne(u => u.User)
                .WithMany(ur => ur.UserReservations)
                .HasForeignKey(fk => new { fk.UserID })
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserReservation>()
                .HasOne(u => u.Reservation)
                .WithMany(ur => ur.UserReservations)
                .HasForeignKey(fk => new { fk.ReservationID })
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Reservation>()
                .HasOne(lm => lm.Limitations)
                .WithOne(rv => rv.Reservation)
                .HasForeignKey<Limitations>(lm => lm.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(rv => rv.Reservation)
                .WithMany(cm => cm.Comments)
                .HasForeignKey(fk => new { fk.ReservationID })
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Reservation>()
               .HasOne(p => p.Place)
               .WithMany(r => r.Reservations)
               .HasForeignKey(fk => new { fk.PlaceID })
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(r => r.Reservations)
                .WithOne(u => u.User)
                .HasForeignKey(fk => fk.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<UserReservation> UserReservation { get; set; }
        public DbSet<Limitations> Limitations { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<PremiumSubscription> PremiumSubscription { get; set; }
        public DbSet<Place> Place { get; set; }
    }
}
