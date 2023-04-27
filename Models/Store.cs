using System.Xml.XPath;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering; 
namespace stationary_shop.Models
{
    public class Store
    {
        [DisplayName("Id")]
        [Required]
        public int Id {get ; set; }

        [DisplayName("Name")]
        [Required]
        public string Name  {get ; set; }

        [DisplayName("Location")]
        [Required]
        public string Location {get ; set; }

        [DisplayName("Phone number")]
        [Required]
        public string Number {get ; set; }

        [DisplayName("Email")]
        [Required]
        public string Mail {get ; set; }

        [DisplayName("Manager")]
        [Required]
        public string Manager {get ; set; 
        }
        [DisplayName("Work hours")]
        [Required]
        public string WorkHours {get ; set; }

    }
}