using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Data
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string title { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public int numberOfPeople { get; set; }
        public string status { get; set; }
        public string LocationID { get; set; }
        
        public virtual ICollection<UserReservation> UserReservations { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Limitations Limitations { get; set; }

    }
}
