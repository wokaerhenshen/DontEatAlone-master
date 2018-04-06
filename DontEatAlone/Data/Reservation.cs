using DontEatAlone.Models;
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
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int NumberOfPeople { get; set; }
        public string Status { get; set; }
        public string PlaceID { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<UserReservation> UserReservations { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Limitations Limitations { get; set; }
        public virtual Place Place { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
