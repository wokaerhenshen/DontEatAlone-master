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

        public List<ReservationVM> GetAllReservations()
        {
            return new List<ReservationVM>();
        }

        public int GenerateReservationId()
        {
            if (_context.Reservation.Count() == 0)
            {
                return 1;
            }
            else
            {
                return _context.Reservation.Select(o => o.id).Max() + 1;
            }
        }

        public ReservationVM GetReservation(int id)
        {
            return new ReservationVM();
        }

        public bool UpdateReservation(ReservationVM r)
        {
            return true;
        }

        public bool DeleteReservation(int id)
        {
            return true;
        }

        public bool CreateReservation(ReservationVM r)
        {
            return true;
        }
    }
}
