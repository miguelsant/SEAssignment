using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
namespace DataAccess
{
    public class UserRepository : ConnectionClass
    {

        public List<User> getAllUsers()
        {
            List<User> myUsers = (from users in MarketplaceEntity.Users
                                  select users).ToList();
            return myUsers; ;

        }


    }
}
