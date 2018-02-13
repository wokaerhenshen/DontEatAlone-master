using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DontEatAlone.Models;

namespace DontEatAlone.Data
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        public string email { get; set; }
        public string userType { get; set; }
        public string phoneNumber { get; set; }
        public string gender { get; set; }
        public string dateOfBirth { get; set; }

        //public virtual 
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual PremiumSubscription PremiumSubscription { get; set; } 
        public virtual ICollection<UserReservation> UserReservations { get; set; }

    }
}
