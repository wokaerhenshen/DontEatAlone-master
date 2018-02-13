using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Data
{
    public class UserReservation
    {
        [Key, Column(Order = 0)]
        public string userID { get; set; }
        [Key, Column(Order = 1)]
        public int reservationID { get; set; }
        public bool isHost { get; set; }

        public virtual User User {get;set;}
        public virtual Reservation Reservation { get; set; }
    }
}
