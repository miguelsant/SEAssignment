using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TradersMarket.Models
{
    public class ProductModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        public string prodName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string prodDescription { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "Price must be at least 1", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Price")]
        public string Price { get; set; }

    }
}