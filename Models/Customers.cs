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
    public class Customers
    {
        [DisplayName("Id")]
        [Required]
        public int Id {get ; set; }

        [DisplayName("First name")]
        [Required]
        public string Name  {get ; set; }

        [DisplayName("Last name")]
        [Required]
        public string Surname {get ; set; }

        [DisplayName("Contact email")]
        [Required]
        public string Mail {get ; set; }

        [DisplayName("Phone number")]
        [Required]
        public string PhoneNumber {get ; set; }

        [DisplayName("Birth date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        public DateTime? BirthDate  {get ; set; }

         [DisplayName("Loyalty program membership")]
        [Required]
        public int LoyaltyProgramMembership {get ; set; }

    }
}