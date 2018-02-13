using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Data
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public int reservationID { get; set; }
        public string body { get; set; }
        public string authorID { get; set; }
        public DateTime date { get; set; }
        
        public virtual Reservation Reservation { get; set; }
    }
}
