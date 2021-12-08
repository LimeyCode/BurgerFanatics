using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerFnatics.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        [Display(Name = "Restaurant Name")]
        public string RestaurantName { get; set; }

        [Display(Name = "Opening Times")]
        public string OpeningTimes { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public virtual Location Location { get; set; }

        public Restaurant()
        {

        }
    }
}
