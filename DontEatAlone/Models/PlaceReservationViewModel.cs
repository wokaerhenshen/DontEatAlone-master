using DontEatAlone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Models
{
    public class PlaceReservationViewModel
    {
        public List<Place> Places { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
