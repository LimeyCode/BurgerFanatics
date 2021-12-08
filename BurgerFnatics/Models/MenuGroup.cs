using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerFnatics.Models
{
    public class MenuGroup
    {
        [Key]
        public int MenuGroupID { get; set; }

        [ForeignKey("Menu")]
        public int MenuID { get; set; }

        public virtual Menu Menu { get; set; }

        [Required(ErrorMessage = "A title is required")]
        [Display(Name = "Menu Group Name")]
        public string MenuGroupName { get; set; }

        [Display(Name = "Description")]
        public string MenuGroupDescription { get; set; }
    }
}
