using DontEatAlone.Data;
using DontEatAlone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Repo
{
    public class ReservationRepository
    {

        ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Reservation> GetAllReservations()
        {
            return _context.Reservation.ToList();
        }

        public int GenerateReservationId()
        {
            if (_context.Reservation.Count() == 0)
            {
                return 1;
            }
            else
            {
                return _context.Reservation.Select(o => o.Id).Max() + 1;
            }
        }

        public Reservation GetReservation(int id)
        {
            return _context.Reservation.Where(r => r.Id == id).FirstOrDefault();
        }

        public string getLocationNameByReservationId(int id)
        {
           return  _context.Reservation.Where(r => r.Id == id).Select(pl => pl.Place.Name).FirstOrDefault();
        }

        public string getAddressByReservationId(int id)
        {
            return _context.Reservation.Where(r => r.Id == id).Select(pl => pl.Place.Address).FirstOrDefault();
        }

        public string getLimitationByReservationId(int id)
        {

            Limitations limitations = _context.Limitations.Where(r => r.Id == id).FirstOrDefault();

            string sex = "Gender: " + limitations.Gender + ".";
            string cuisineType = "Cussine Type: " + limitations.CuisineType + ".";
            string age = "Age "+limitations.Age + ".";
            string smoking = "";
            string pets = "";
            string alcohol = "";
            if (limitations.Smoking == true)
            {
                 smoking = " Smoking Allowed.";
            }else
            {
                smoking = " Smoking Not Allowed.";
            }

            if (limitations.Pets == true)
            {
                pets = " Pets Allowed.";
            }else
            {
                pets = " Pets Not Allowed.";
            }
            if (limitations.Alcohol == true)
            {
                alcohol = " Alcohol Allowed.";
            }else
            {
                alcohol = " Alcohol Not Allowed.";
            }



            
            
            string languages = "Languages: " + limitations.Languages + ".";
            string description = "Description: "+ limitations.Description + ".";

            string thisLimiation = sex + " " + cuisineType + " " + age + " " + smoking + " " + pets + " " + alcohol +" " + languages + " " + description;

            return thisLimiation;
        }

        public Limitations getLimitationByReservationId(int id, string reservationId) //second parameter just to let method override
        {
            string sex = _context.Reservation.Where(r => r.Id == id).Select(lm => lm.Limitations.Gender).FirstOrDefault();
            string cuisineType = _context.Reservation.Where(r => r.Id == id).Select(lm => lm.Limitations.CuisineType).FirstOrDefault();
            string age = _context.Reservation.Where(r => r.Id == id).Select(lm => lm.Limitations.Age).FirstOrDefault();
            bool smoking = _context.Reservation.Where(r => r.Id == id).Select(lm => lm.Limitations.Smoking).FirstOrDefault();
            bool pets = _context.Reservation.Where(r => r.Id == id).Select(lm => lm.Limitations.Pets).FirstOrDefault();
            string languages = _context.Reservation.Where(r => r.Id == id).Select(lm => lm.Limitations.Languages).FirstOrDefault();
            string description = _context.Reservation.Where(r => r.Id == id).Select(lm => lm.Limitations.Description).FirstOrDefault();
            bool alcohol = _context.Reservation.Where(r => r.Id == id).Select(lm => lm.Limitations.Alcohol).FirstOrDefault();

            return new Limitations()
            {
                Gender = sex,
                CuisineType = cuisineType,
                Age = age,
                Smoking = smoking,
                Pets = pets,
                Alcohol = alcohol,
                Languages = languages
            };
        }

        public List<Reservation> filterReservationByLimitations(List<Reservation> reservations, Limitations limitations)
        {
            List<Reservation> result = new List<Reservation>();
            foreach (Reservation r in reservations)
            {
                Limitations rLimititions = getLimitationByReservationId(r.Id, r.Title);
                if (
                        (limitations.Gender == null || rLimititions.Gender.Equals(limitations.Gender, StringComparison.InvariantCultureIgnoreCase)) &&
                        (limitations.Languages == null || rLimititions.Languages.Equals(limitations.Languages, StringComparison.InvariantCultureIgnoreCase)) &&
                        (limitations.CuisineType == null || limitations.CuisineType.Equals(rLimititions.CuisineType, StringComparison.InvariantCultureIgnoreCase)) &&
                        (limitations.Age == null || limitations.Age.Equals(rLimititions.Age, StringComparison.InvariantCultureIgnoreCase)) &&
                        (limitations.Pets == false || limitations.Pets == rLimititions.Pets) &&
                        (limitations.Alcohol == false || limitations.Alcohol == rLimititions.Alcohol) &&
                        (limitations.Smoking == false || limitations.Smoking == rLimititions.Smoking) 
                    )
                {
                    result.Add(r);
                }
            }

            return result;
        }

        public bool UpdateReservation(Reservation res)
        {
            Reservation reservation = _context.Reservation.Where(r => r.Id == res.Id).FirstOrDefault();
            if (reservation != null)
            {
                reservation.Title = res.Title;
                reservation.DateStart = new DateTime(res.DateStart.Millisecond);
                reservation.DateEnd = new DateTime(res.DateEnd.Millisecond);
                reservation.NumberOfPeople = res.NumberOfPeople;
                reservation.Status = res.Status;
                reservation.PlaceID = res.PlaceID;
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool DeleteReservation(int id)
        {
            Reservation res = _context.Reservation.Where(r => r.Id == id).FirstOrDefault();
            if (res != null)
            {
                _context.Remove(res);
                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public bool CreateReservation(Reservation reservation)
        {
            Reservation r = new Reservation();
            r.Id = reservation.Id;
            r.Title = reservation.Title;
            r.DateStart = reservation.DateStart;
            r.DateEnd = reservation.DateEnd;
            r.NumberOfPeople = reservation.NumberOfPeople;
            r.Status = reservation.Status;
            r.PlaceID = reservation.PlaceID;
            r.UserId = reservation.UserId;
            _context.Reservation.Add(r);
            _context.SaveChanges();

            return true;
        }

        public List<Comment> getCommentsByReservationId(int id)
        {
            return _context.Comment.Where(i => i.ReservationID == id).ToList();
        }

        public User getHostByReservationId(int id)
        {
            string userID = _context.UserReservation.Where(ur => ur.ReservationID == id && ur.isHost == true).Select(ui => ui.UserID).FirstOrDefault();
            return _context.User.Where(ui => ui.Id == userID).FirstOrDefault();
        }

        public List<User> getParticipantByReservationId(int id)
        {
            List<string> usersID = _context.UserReservation.Where(ur => ur.ReservationID == id && ur.isHost == false && ur.status == "approved").Select(ui => ui.UserID).ToList();
            List<User> users = new List<User>();
            foreach(var userID in usersID)
            {
                User user = _context.User.Where(ui => ui.Id == userID).FirstOrDefault();
                users.Add(user);
                

            }
            return users;
        }

        public List<Reservation> getReservationsByUserId(string userId)
        {
            return _context.Reservation.Where(ui => ui.UserId == userId).ToList();
        }

        public List<RequestVM> GetRequestsByUserId(string userId)
        {
            IEnumerable<RequestVM> query = from r in _context.UserReservation
                                    where (r.UserID == userId && r.isHost == false)
                                    select new RequestVM
                                    {
                                        ReservationTitle = r.Reservation.Title,
                                        ReservationLocation = r.Reservation.Place.Name,
                                        status = r.status

                                    };
            return query.ToList();
        }

        public IEnumerable<RequestManagementVM> GetAllRequestForManagement(int id)
        {
            IEnumerable<RequestManagementVM> query = from r in _context.UserReservation
                                                     where (r.ReservationID == id && r.isHost == false)
                                                     select new RequestManagementVM
                                                     {
                                                         ReservationId = r.ReservationID,
                                                         UserId = r.UserID,
                                                         Email = r.User.Email,
                                                         FirstName = r.User.FirstName,
                                                         Status = r.status,
                                                         Gender = r.User.Gender,
                                                         BirthDay = r.User.DateOfBirth
                                                     };
            return query;
        } 

        public bool placeIdExist(string placeId)
        {
          string name =  _context.Place.Where(i => i.Id == placeId).Select(place=> place.Name).FirstOrDefault();
            if (name != null)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
