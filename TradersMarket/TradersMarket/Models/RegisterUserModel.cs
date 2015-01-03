using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TradersMarket.Models
{
    public class RegisterUserModel
    {
        [Required]
        [StringLength(25, ErrorMessage = "Username must be between 5 and 25 characters.", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Password must be between 6 and 30 characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Name must be between 2 and 25 characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Surname must be between 2 and 25 characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Surname")]
        public string surname { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "Mobile number must be 8 characters long.", MinimumLength = 8)]
        [DataType(DataType.Text)]
        [Display(Name = "Mobile Number")]
        public string mobileNumber { get; set; }



        public bool Subscribe { get; set; }
        public int TownID { get; set; }
        public int RoleID { get; set; }
    }
}