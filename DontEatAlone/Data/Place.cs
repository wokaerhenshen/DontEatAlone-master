using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Data
{
    public class Place
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
