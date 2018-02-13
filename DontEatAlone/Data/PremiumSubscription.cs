using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Data
{
    public class PremiumSubscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool payment { get; set; }

        public virtual User User { get; set; }
    }
}
