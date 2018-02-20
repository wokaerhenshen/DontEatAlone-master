using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Models
{
    public class ReservationVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int PeopleNumber { get; set; }
        public string Status { get; set; }
        public string LocationID { get; set; }
    }
}
