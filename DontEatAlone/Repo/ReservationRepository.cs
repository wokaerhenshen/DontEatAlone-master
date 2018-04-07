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
            string sex = "Gender: " + _context.Reservation.Where(r => r.Id == id).Select(lm => lm.Limitations.Gender).FirstOrDefault();
            string cuisineType = "Cussine Type: " + _context.Reservation.Where(r => r.Id == id).Select(lm => lm.Limitations.CuisineType).FirstOrDefault();
            string age = "Age "+_context.Reservation.Where(r => r.Id == id).Select(lm => lm.Limitations.Age).FirstOrDefault();
            string smoking = " Smoke: " + _context.Reservation.Where(r => r.Id == id).Select(lm => lm.Limitations.Smoking).FirstOrDefault();
            string pets = " Pets: " + _context.Reservation.Where(r => r.Id == id).Select(lm => lm.Limitations.Pets).FirstOrDefault();
            string languages = "Languages: " + _context.Reservation.Where(r => r.Id == id).Select(lm => lm.Limitations.Languages).FirstOrDefault();
            string description = "Description: "+ _context.Reservation.Where(r => r.Id == id).Select(lm => lm.Limitations.Description).FirstOrDefault();

            string limiations = sex + " " + cuisineType + " " + age + " " + smoking + " " + pets + " " + languages + " " + description;

            return limiations;
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
