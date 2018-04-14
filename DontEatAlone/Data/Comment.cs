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
        public int Id { get; set; }
        public int ReservationID { get; set; }
        public string Body { get; set; }
        public string AuthorID { get; set; }
        public string AuthorFirstName { get; set; }
        public DateTime Date { get; set; }
        
        public virtual Reservation Reservation { get; set; }
    }
}
