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
                reservation.LocationID = res.LocationID;
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
            r.Title = reservation.Title;
            r.DateStart = new DateTime(reservation.DateStart.Millisecond);
            r.DateEnd = new DateTime(reservation.DateEnd.Millisecond);
            r.NumberOfPeople = reservation.NumberOfPeople;
            r.Status = reservation.Status;
            r.LocationID = reservation.LocationID;
            _context.Add(r);
            _context.SaveChanges();

            return true;
        }
    }
}
