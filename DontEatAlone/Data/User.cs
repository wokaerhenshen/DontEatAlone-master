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
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }

        //public virtual 
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual PremiumSubscription PremiumSubscription { get; set; } 
        public virtual ICollection<UserReservation> UserReservations { get; set; }

    }
}
