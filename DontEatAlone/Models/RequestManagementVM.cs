using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Models
{
    public class RequestManagementVM
    {
        public int ReservationId { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Status { get; set; }

    }
}
