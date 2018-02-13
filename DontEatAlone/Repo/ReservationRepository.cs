using DontEatAlone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Repo
{
    public class ReservationRepository
    {
        public List<Reservation> GetAllReservations()
        {
            return new List<Reservation>();
        }

        public Reservation GetReservation(int id)
        {
            return new Reservation();
        }

        public bool UpdateReservation(Reservation r)
        {
            return true;
        }

        public bool DeleteReservation(int id)
        {
            return true;
        }

        public bool CreateReservation(Reservation r)
        {
            return true;
        }
    }
}
