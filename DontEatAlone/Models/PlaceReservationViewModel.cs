using DontEatAlone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Models
{
    public class PlaceReservationViewModel
    {
        public List<ReservationViewModel> Reservations { get; set; } 
        public List<Place> Places { get; set; }
    }
}
