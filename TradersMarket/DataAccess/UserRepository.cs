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

        public UserRole getUserRole(int userroleid)
        {
            UserRole usr = (from user in MarketplaceEntity.UserRoles
                            where user.RoleID == userroleid
                            select user).SingleOrDefault();
            return usr;
                            
        }

        public void UpdateUserRole(UserRole usr)
        {
            MarketplaceEntity.UserRoles.Attach(getUserRole(usr.UserRoleID));
            MarketplaceEntity.UserRoles.ApplyCurrentValues(usr);
            MarketplaceEntity.SaveChanges();
        }

        public void UpdateUser(User us)
        {
            MarketplaceEntity.Users.Attach(getUserByUsername(us.Username));
            MarketplaceEntity.Users.ApplyCurrentValues(us);
            MarketplaceEntity.SaveChanges();

        }
        public UserRole getUsersUserRole(string username)
        {
            UserRole r = (from userr in MarketplaceEntity.UserRoles
                          where userr.Username == username
                          select userr).SingleOrDefault();
            return r;
        }
        public Role getRoleByID(int roleID)
        {
            Role r = (from role in MarketplaceEntity.Roles
                      where role.RoleID == roleID
                      select role).SingleOrDefault();
            return r;
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

        public UserRole getRoleByUsername(string username)
        {
            UserRole u = (from userrole in MarketplaceEntity.UserRoles
                          where userrole.Username == username
                          select userrole).SingleOrDefault();
            return u;
        }

        public void addUser(User u)
        {
            MarketplaceEntity.AddToUsers(u);
            MarketplaceEntity.SaveChanges();
        }


        public string getRoleName(int roleID)
        {
            string roleName = (from role in MarketplaceEntity.Roles
                      where role.RoleID == roleID
                      select role.RoleName).SingleOrDefault();
            return roleName;
        }

        public User getUserByUsername(string username)
        {
            User u = (from user in MarketplaceEntity.Users
                      where user.Username == username
                      select user).SingleOrDefault();
            return u;

        }

        public string getTownName(int townID)
        {
            Town twn = (from town in MarketplaceEntity.Towns
                        where town.TownID == townID
                        select town).SingleOrDefault();
            return twn.TownName;

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


        public void DeleteUser(string username)
        {
            User userToDelete = getUserByUsername(username);
            MarketplaceEntity.DeleteObject(userToDelete);
            MarketplaceEntity.SaveChanges();
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
