using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Models
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int NumberOfPeople { get; set; }
        public string Status { get; set; }
        public string AuthorName { get; set; }
        public string LocationAddress { get; set; }
    }
}
