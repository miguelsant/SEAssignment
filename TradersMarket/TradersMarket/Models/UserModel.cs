using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradersMarket.Models
{
    public class UserModel
    {

        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mobile { get; set; }
        public string TownName { get; set; }
        public int TownID { get; set; }
    }
}