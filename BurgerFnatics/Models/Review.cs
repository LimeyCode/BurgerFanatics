using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerFnatics.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        [Display(Name = "Review Title")]
        public string Title { get; set; }

        [Display(Name = "Taste Rating from 1 - 5")]
        public int TasteRating { get; set; }

        [Display(Name = "Texture Rating from 1 - 5")]
        public int TextureRating { get; set; }

        [Display(Name = "Visual Rating from 1 - 5")]
        public int VisualRating { get; set; }

        public string ImagePath { get; set; }
    }
}
