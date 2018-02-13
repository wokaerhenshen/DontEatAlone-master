using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DontEatAlone.Data
{
    public class Limitations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string gender { get; set; }
        public string cuisineType { get; set; }
        public string age { get; set; }
        public bool smoking { get; set; }
        public bool pets { get; set; }
        public bool alcohol { get; set; }
        public string languages { get; set; }
        public string description { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
