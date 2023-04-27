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
    public class Orders
    {
        [DisplayName("Id")]
        [Required]
        public int Id {get ; set; }

        [DisplayName("Order date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        public DateTime? OrderDate  {get ; set; }

        [DisplayName("Order status")]
        [Required]
        public int OrderStatus {get ; set; }

        [DisplayName("Payment status")]
        [Required]
        public int PaymentStatus {get ; set; }

        [DisplayName("Shipping adress")]
        [Required]
        public string ShippingAdress {get ; set; }

    }
}