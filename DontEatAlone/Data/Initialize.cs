using DontEatAlone.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Data
{
    public class Initialize
    {
        private ApplicationDbContext _context;
        ReservationRepository rr;
        //= new ReservationRepository(_context);
        public Initialize(ApplicationDbContext context)
        {
            _context = context;
            this.rr = new ReservationRepository(context);
            //InitializeData();
        }

        public void InitializeData()
        {
           if (_context.Reservation.Count() == 0)
            {
                _context.Reservation.Add(new Reservation
                {
                    Id = 1,
                    Title = "my_first_reservation"
                });

               // _context.SaveChanges();

                _context.Reservation.Add(new Reservation
                {
                    Id = 2,
                    Title = "my_second_reservation"
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
           //else
           // {
           //     CleanData();
           // }
        }

        public void CleanData()
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
