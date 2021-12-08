using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerFnatics.Models
{
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        [Display(Name = "Menu Name")]
        public string MenuName { get; set; }

        [Display(Name = "Description")]
        public string MenuDescription { get; set; }

        public virtual List<MenuItem> MenuItems { get; set; }

        public virtual List<MenuGroup> MenuGroups { get; set; }
    }
}
