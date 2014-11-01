using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using Common;
namespace BusinessLayer
{
    public class UserBL
    {
        public List<User> getAllUsers()
        {
            return new UserRepository().getAllUsers();

        }
    }
}
