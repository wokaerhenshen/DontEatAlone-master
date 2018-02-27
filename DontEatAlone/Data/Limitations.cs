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
        public int Id { get; set; }
        public string Gender { get; set; }
        public string CuisineType { get; set; }
        public string Age { get; set; }
        public bool Smoking { get; set; }
        public bool Pets { get; set; }
        public bool Alcohol { get; set; }
        public string Languages { get; set; }
        public string Description { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
