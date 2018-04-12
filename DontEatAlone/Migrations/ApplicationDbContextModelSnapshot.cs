﻿// <auto-generated />
using DontEatAlone.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DontEatAlone.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("DontEatAlone.Data.Comment", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("AuthorFirstName");

                    b.Property<string>("AuthorID");

                    b.Property<string>("Body");

                    b.Property<DateTime>("Date");

                    b.Property<int>("ReservationID");

                    b.HasKey("Id");

                    b.HasIndex("ReservationID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("DontEatAlone.Data.Limitations", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Age");

                    b.Property<bool>("Alcohol");

                    b.Property<string>("CuisineType");

                    b.Property<string>("Description");

                    b.Property<string>("Gender");

                    b.Property<string>("Languages");

                    b.Property<bool>("Pets");

                    b.Property<bool>("Smoking");

                    b.HasKey("Id");

                    b.ToTable("Limitations");
                });

            modelBuilder.Entity("DontEatAlone.Data.Place", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Address");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longtitude");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("DontEatAlone.Data.PremiumSubscription", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("Payment");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("PremiumSubscription");
                });

            modelBuilder.Entity("DontEatAlone.Data.Reservation", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime>("DateEnd");

                    b.Property<DateTime>("DateStart");

                    b.Property<int>("NumberOfPeople");

                    b.Property<string>("PlaceID");

                    b.Property<string>("Status");

                    b.Property<string>("Title");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("PlaceID");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("DontEatAlone.Data.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("profileImg");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DontEatAlone.Data.UserReservation", b =>
                {
                    b.Property<string>("UserID");

                    b.Property<int>("ReservationID");

                    b.Property<bool>("isHost");

                    b.Property<string>("status");

                    b.HasKey("UserID", "ReservationID");

                    b.HasAlternateKey("ReservationID", "UserID");

                    b.ToTable("UserReservation");
                });

            modelBuilder.Entity("DontEatAlone.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DontEatAlone.Data.Comment", b =>
                {
                    b.HasOne("DontEatAlone.Data.Reservation", "Reservation")
                        .WithMany("Comments")
                        .HasForeignKey("ReservationID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DontEatAlone.Data.Limitations", b =>
                {
                    b.HasOne("DontEatAlone.Data.Reservation", "Reservation")
                        .WithOne("Limitations")
                        .HasForeignKey("DontEatAlone.Data.Limitations", "Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DontEatAlone.Data.PremiumSubscription", b =>
                {
                    b.HasOne("DontEatAlone.Data.User", "User")
                        .WithOne("PremiumSubscription")
                        .HasForeignKey("DontEatAlone.Data.PremiumSubscription", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DontEatAlone.Data.Reservation", b =>
                {
                    b.HasOne("DontEatAlone.Models.ApplicationUser")
                        .WithMany("Reservations")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("DontEatAlone.Data.Place", "Place")
                        .WithMany("Reservations")
                        .HasForeignKey("PlaceID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DontEatAlone.Data.User", b =>
                {
                    b.HasOne("DontEatAlone.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("User")
                        .HasForeignKey("DontEatAlone.Data.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DontEatAlone.Data.UserReservation", b =>
                {
                    b.HasOne("DontEatAlone.Data.Reservation", "Reservation")
                        .WithMany("UserReservations")
                        .HasForeignKey("ReservationID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DontEatAlone.Data.User", "User")
                        .WithMany("UserReservations")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DontEatAlone.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DontEatAlone.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DontEatAlone.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DontEatAlone.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
