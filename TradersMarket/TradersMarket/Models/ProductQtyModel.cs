using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TradersMarket.Models
{
    public class ProductQtyModel
    {
        [Required]
        [StringLength(2, ErrorMessage = "Quantity can only be between 1 and 99", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Product Quantity")]
        public string Quantity { get; set; }


        public string CartID { get; set; }
    }
}