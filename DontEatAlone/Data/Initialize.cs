using DontEatAlone.Models;
using DontEatAlone.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Data
{
    public class Initialize
    {
        private ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;
        ReservationRepository rr;
        //= new ReservationRepository(_context);
        public Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            this.rr = new ReservationRepository(context);
            InitUsers();
            initPlaces();
            InitializeData();
            //CleanData();
        }

        private void InitializeData()
        {
            if (_context.Reservation.Count() == 0)
            {
                ApplicationUser user = _context.ApplicationUser.FirstOrDefault();
                _context.Reservation.Add(new Reservation
                {
                    Id = 1,
                    Title = "Pasta day",
                    PlaceID = _context.Place.Where(p => p.Name == "BCIT Downtown").FirstOrDefault().Id,
                    NumberOfPeople = 3,
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddHours(5),
                    UserId = user.Id
                });

                // _context.SaveChanges();

                _context.Reservation.Add(new Reservation
                {
                    Id = 2,
                    Title = "Tiesto pre party",
                    PlaceID = _context.Place.Where(p => p.Name == "BCIT Downtown").FirstOrDefault().Id,
                    NumberOfPeople = 5,
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddHours(1),
                    UserId = user.Id
                });

                _context.Reservation.Add(new Reservation()
                {
                    Id = 3,
                    Title = "Party hard like Putin",
                    PlaceID = _context.Place.Where(p => p.Name == "Black & Blue").FirstOrDefault().Id,
                    NumberOfPeople = 3,
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddHours(0.5),
                    UserId = user.Id
                });

                _context.Reservation.Add(new Reservation()
                {
                    Id = 4,
                    Title = "Good conversation and vibes",
                    PlaceID = _context.Place.Where(p => p.Name == "Italian Kitchen").FirstOrDefault().Id,
                    NumberOfPeople = 2,
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddHours(1),
                    UserId = user.Id
                });

                _context.Reservation.Add(new Reservation()
                {
                    Id = 5,
                    Title = "We're going for the whole course",
                    PlaceID = _context.Place.Where(p => p.Name == "Cactus Club Cafe").FirstOrDefault().Id,
                    NumberOfPeople = 5,
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddHours(4),
                    UserId = user.Id
                });

                _context.Reservation.Add(new Reservation()
                {
                    Id = 6,
                    Title = "Free vodka",
                    PlaceID = _context.Place.Where(p => p.Name == "Cactus Club Cafe").FirstOrDefault().Id,
                    NumberOfPeople = 4,
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddHours(2),
                    UserId = user.Id
                });

                _context.SaveChanges();

                _context.UserReservation.Add(new UserReservation
                {
                    UserID = _context.User.FirstOrDefault().Id,
                    ReservationID = 1,
                    IsHost = true
                });

                _context.UserReservation.Add(new UserReservation
                {
                    UserID = _context.User.FirstOrDefault().Id,
                    ReservationID = 2,
                    IsHost = true
                });

                _context.SaveChanges();

                _context.Limitations.Add(new Limitations
                {
                    Id = 1,
                    Gender = "male",
                    CuisineType = "chinese",
                    Age = "any",
                    Smoking = false,
                    Pets = false,
                    Alcohol = false,
                    Languages = "chinese",
                    Description = "hello welcome!"
                });

                _context.Limitations.Add(new Limitations
                {
                    Id = 2,
                    Gender = "female",
                    CuisineType = "Canada",
                    Age = "over 18",
                    Smoking = false,
                    Pets = false,
                    Alcohol = false,
                    Languages = "English",
                    Description = "welcome lady!!"
                });

                _context.Limitations.Add(new Limitations
                {
                    Id = 3,
                    Gender = "man",
                    CuisineType = "Chinese",
                    Age = "18-34",
                    Smoking = true,
                    Pets = true,
                    Alcohol = false,
                    Languages = "Chinese and English",
                    Description = "welcome any people of the world!"
                });

                _context.Limitations.Add(new Limitations
                {
                    Id = 4,
                    Gender = "man",
                    CuisineType = "Chinese",
                    Age = "18-34",
                    Smoking = true,
                    Pets = true,
                    Alcohol = false,
                    Languages = "Chinese and English",
                    Description = "welcome any people of the world!"
                });

                _context.Limitations.Add(new Limitations
                {
                    Id = 5,
                    Gender = "man",
                    CuisineType = "Chinese",
                    Age = "18-34",
                    Smoking = true,
                    Pets = true,
                    Alcohol = false,
                    Languages = "Chinese and English",
                    Description = "welcome any people of the world!"
                });

                _context.Limitations.Add(new Limitations
                {
                    Id = 6,
                    Gender = "man",
                    CuisineType = "Chinese",
                    Age = "18-34",
                    Smoking = true,
                    Pets = true,
                    Alcohol = false,
                    Languages = "Chinese and English",
                    Description = "welcome any people of the world!"
                });

                _context.SaveChanges();

                _context.Comment.Add(new Comment
                {
                    Id = 1,
                    Body = "very nice man!",
                    AuthorID = _context.User.FirstOrDefault().Id,
                    Date = DateTime.Now,
                    ReservationID = 1
                });

                _context.Comment.Add(new Comment
                {
                    Id = 2,
                    Body = "very good man!",
                    AuthorID = _context.User.FirstOrDefault().Id,
                    Date = DateTime.Now,
                    ReservationID = 1
                });

                _context.Comment.Add(new Comment
                {
                    Id = 3,
                    Body = "very beautiful lady!",
                    AuthorID = _context.User.FirstOrDefault().Id,
                    Date = DateTime.Now,
                    ReservationID = 2
                });


                _context.Comment.Add(new Comment
                {
                    Id = 4,
                    Body = "like her so much!",
                    AuthorID = _context.User.FirstOrDefault().Id,
                    Date = DateTime.Now,
                    ReservationID = 2
                });

                _context.SaveChanges();

            }
        }

        private void initPlaces()
        {
            if (_context.Place.Count() == 0)
            {
                _context.Place.Add(new Place()
                {
                    Id="ChIJ4S7wxnhxhlQRFGfmMvQ74LQ",
                    Latitude = 49.2834511,
                    Longtitude = -123.1174435,
                    Name = "BCIT Downtown",
                    Address = "555 Seymour St"
                });
                _context.Place.Add(new Place()
                {
                    Id = "ChIJu1r9tIFxhlQRsfy5cILqdDs",
                    Latitude = 49.2808611,
                    Longtitude = -123.1168084,
                    Name = "Black & Blue",
                    Address = "1032 Alberni Street, Vancouver, BC V6Z 2V6"
                });
                _context.Place.Add(new Place()
                {
                    Id = "ChIJ3U0lgH9xhlQRtGkKYvE4DCA",
                    Latitude = 49.282966,
                    Longtitude = -123.122885,
                    Name = "Art gallery",
                    Address = "750 Hornby St, Vancouver, BC V6Z 2H7",
                });
                _context.Place.Add(new Place()
                {
                    Id = "ChIJhyhZHIBxhlQRVoXcHbmpVSo",
                    Latitude = 49.282805,
                    Longtitude = -123.120475,
                    Name = "Italian Kitchen",
                    Address = "860 Burrard St, Vancouver, BC V6Z 1X9"
                });
                _context.Place.Add(new Place()
                {
                    Id = "ChIJ4Vnv6dZzhlQRMLbmj6Ca0rU",
                    Latitude = 49.275073,
                    Longtitude = -123.122762,
                    Name = "Cactus Club Cafe",
                    Address = "357 Davie St, Vancouver, BC V6B 1R2"
                });
                _context.SaveChanges();
            }
        }

        private void InitUsers()
        {
            // Check for _context.ApplicationUser.Where for count > 0 if yes, confirmed account 
            ApplicationUser testIfExists = _context.ApplicationUser.Where(au => au.Email.Equals("admin@admin.com")).FirstOrDefault();
            if (testIfExists == null)
            {
                _userManager.CreateAsync(new ApplicationUser()
                {
                    UserName = "admin@user.com",
                    Email = "admin@user.com",
                }, "Bcit123!");
            }
        }

        private void CleanData()
        {
            foreach (var co in _context.Comment)
            {
                _context.Comment.Remove(co);
            }
            _context.SaveChanges();

            foreach (var li in _context.Limitations)
            {
                _context.Limitations.Remove(li);
            }
            _context.SaveChanges();

            foreach (var ur in _context.UserReservation)
            {
                _context.UserReservation.Remove(ur);
            }
            _context.SaveChanges();

            foreach (var re in _context.Reservation)
            {
                _context.Reservation.Remove(re);
            }
            _context.SaveChanges();
        }
    }
}
