using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerFnatics.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public string Postcode { get; set; }

        [Display(Name = "Road Name")]
        public string RoadName { get; set; }
    }
}
