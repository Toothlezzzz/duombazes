using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stationary_shop.Models
{
    public class Products
    {
        [DisplayName("ID")]
        [Key]
        [Required]
        public int ID {get ; set; }

        [DisplayName("Name")]
        [Required]
        public string Name  {get ; set; }

        [DisplayName("Description")]
        [Required]
        public string Description {get ; set; }

        [DisplayName("Price")]
        [Required]
        public int Price {get ; set; }

        [DisplayName("Category")]
        [Required]
        public string Category {get ; set; }

        [DisplayName("Brand")]
        [Required]
        public string Brand {get ; set; 
        }
        [DisplayName("Size")]
        [Required]
        public string Size {get ; set; }

    }
}