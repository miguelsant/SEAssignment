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
        [StringLength(50, ErrorMessage = "Description length must be between 8 and 50.", MinimumLength = 8)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string prodDescription { get; set; }


        [Required]
        [StringLength(5, ErrorMessage = "*", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Price")]
        public string Price { get; set; }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(3, ErrorMessage = "Must have at least 1 quantity", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Quantity")]
        public string Quantity { get; set; }

    }
}