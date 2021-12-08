using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerFnatics.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemID { get; set; }

        [ForeignKey("Menu")]
        public int MenuID { get; set; }
        public virtual Menu Menu { get; set; }

        [ForeignKey("MenuGroup")]
        public int MenuGroupID { get; set; }
        public virtual MenuGroup MenuGroup { get; set; }

        [Required(ErrorMessage = "A title is required for the menu item")]
        [Display(Name = "Menu Item Name")]
        public string MenuItemName { get; set; }

        [Display(Name = "Description")]
        public string MenuItemDescription { get; set; }

        [Display(Name = "Ingredients")]
        public string MenuItemIngredients { get; set; }


        [Display(Name = "Cost of Menu Item")]
        public Single MenuItemCost { get; set; }
    }
}
