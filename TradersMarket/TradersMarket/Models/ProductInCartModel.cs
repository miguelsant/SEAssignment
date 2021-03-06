﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TradersMarket.Models
{
    public class ProductInCartModel
    {

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "ProductID")]
        public string prodID { get; set; }


        [Required]
        [StringLength(20, ErrorMessage = "Product name must be between 8 and 20 characters.", MinimumLength = 8)]
        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        public string prodName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Description length must be between 8 and 50.", MinimumLength = 8)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string prodDescription { get; set; }


        [Required]
        [StringLength(3, ErrorMessage = "Must have at least 1 product", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Quantity")]
        public string Quantity { get; set; }


        [Required]
        [StringLength(5, ErrorMessage = "*", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Price")]
        public string Price { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "ImageURL")]
        public string ImageURL { get; set; }

        public string cartID { get; set; }
    }
}