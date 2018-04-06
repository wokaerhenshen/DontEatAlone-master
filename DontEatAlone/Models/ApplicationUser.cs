using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DontEatAlone.Data;

namespace DontEatAlone.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
       public virtual User User { get; set; }
       public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
