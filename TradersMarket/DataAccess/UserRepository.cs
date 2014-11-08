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
            return myUsers; 

        }

        public List<Role> getAllRoles()
        {
            List<Role> myRoles = ( from r in MarketplaceEntity.Roles
                           select r).ToList();
            return myRoles;
        }

        public List<Town> getAllTowns()
        {
            List<Town> myTowns = (from t in MarketplaceEntity.Towns
                                  select t).ToList();
            return myTowns;
        }

        public void addUser(User u)
        {
            MarketplaceEntity.AddToUsers(u);
            MarketplaceEntity.SaveChanges();
        }

        public User getUserByUsername(string username)
        {
            User u = (from user in MarketplaceEntity.Users
                      where user.Username == username
                      select user).SingleOrDefault();
            return u;

        }

        public User getUserWithEmail(string email)
        {
            User u = (from user in MarketplaceEntity.Users
                      where user.Email == email
                      select user).SingleOrDefault();
            return u;
        }

        public List<Role> getNonAdminRoles()
        {
            List<Role> roles = (from r in MarketplaceEntity.Roles
                                where r.RoleName != "Admin"
                                select r).ToList();
            return roles;

        }

        public Role getRoleById(int id)
        {
            Role r = (from rol in MarketplaceEntity.Roles
                      where rol.RoleID == id
                      select rol).SingleOrDefault();
            return r;
        }


        public User getUserWithCredentials(string username, string password)
        {
            User u = (from users in MarketplaceEntity.Users
                      where users.Username == username && users.Passwords == password
                      select users).SingleOrDefault();
            return u;

        }

        public void SaveUserRole(UserRole r)
        {
            MarketplaceEntity.AddToUserRoles(r);
            MarketplaceEntity.SaveChanges();
        }

        

    }
}
