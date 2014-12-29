using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TradersMarket.Models
{
    public class UpdateProductModel
    {

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "ProductID")]
        public string prodID { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        public string prodName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string prodDescription { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "Must have at least 1 product", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Quantity")]
        public string Quantity { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "Price must be at least 1", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Price")]
        public string Price { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "ImageURL")]
        public string ImageURL { get; set; }


        public List<SelectListItem> ListCategory { get; set; }

    }
}