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
                    id = 1,
                    title = "my_first_reservation"
                });

               // _context.SaveChanges();

                _context.Reservation.Add(new Reservation
                {
                    id = 2,
                    title = "my_second_reservation"
                });

                _context.SaveChanges();

                _context.UserReservation.Add(new UserReservation
                {
                    userID = _context.User.FirstOrDefault().Id,
                    reservationID = 1,
                    isHost = true
                });

                _context.UserReservation.Add(new UserReservation
                {
                    userID = _context.User.FirstOrDefault().Id,
                    reservationID = 2,
                    isHost = true
                });

                _context.SaveChanges();

                _context.Limitations.Add(new Limitations
                {
                    id = 1,
                    gender = "male",
                    cuisineType = "chinese",
                    age = "any",
                    smoking = false,
                    pets = false,
                    alcohol = false,
                    languages = "chinese",
                    description = "hello welcome!"
                });

                _context.Limitations.Add(new Limitations
                {
                    id = 2,
                    gender = "female",
                    cuisineType = "Canada",
                    age = "over 18",
                    smoking = false,
                    pets = false,
                    alcohol = false,
                    languages = "English",
                    description = "welcome lady!!"
                });

                _context.SaveChanges();

                _context.Comment.Add(new Comment
                {
                    id = 1,
                    body = "very nice man!",
                    authorID = _context.User.FirstOrDefault().Id,
                    date = DateTime.Now,
                    reservationID = 1
                });

                _context.Comment.Add(new Comment
                {
                    id = 2,
                    body = "very good man!",
                    authorID = _context.User.FirstOrDefault().Id,
                    date = DateTime.Now,
                    reservationID = 1
                });

                _context.Comment.Add(new Comment
                {
                    id = 3,
                    body = "very beautiful lady!",
                    authorID = _context.User.FirstOrDefault().Id,
                    date = DateTime.Now,
                    reservationID = 2
                });


                _context.Comment.Add(new Comment
                {
                    id = 4,
                    body = "like her so much!",
                    authorID = _context.User.FirstOrDefault().Id,
                    date = DateTime.Now,
                    reservationID = 2
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
