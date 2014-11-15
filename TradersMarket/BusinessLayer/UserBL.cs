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
        public enum regVerifier {UsernameExists,EmailExists,RegistrationSuccessful};
        public enum loginVerifier { InvalidCredentials, ValidCredentials };
        public List<User> getAllUsers()
        {
            return new UserRepository().getAllUsers();

        }

        public void UpdateUserRole(UserRole r)
        {
            new UserRepository().UpdateUserRole(r);
        }

        public void UpdateUser(User us)
        {
            new UserRepository().UpdateUser(us);
        }

        public UserRole getUsersUserRole(string username)
        {

            return new UserRepository().getUsersUserRole(username);
        }
        public Role getRoleByID(int id)
        {
            return new UserRepository().getRoleById(id);
        }

        public string getUserRole(string username)
        {

            UserRole rol = new UserRepository().getRoleByUsername(username);
            string userroleName = new UserRepository().getRoleName(rol.RoleID);
            return userroleName;
        }

        public void DeleteUser(string username)
        {
            new UserRepository().DeleteUser(username); 
            
        }

        public string getTownName(int townID)
        {
            return new UserRepository().getTownName(townID);
        }

        public List<Role> getAllRoles()
        {
            return new UserRepository().getAllRoles();
        }

        public List<Town> getAllTowns()
        {
            return new UserRepository().getAllTowns();
        }

        public List<Role> getAllNonAdminRoles()
        {
            return new UserRepository().getNonAdminRoles();
        }

        public Enum addUser(string username,string password, string email, string name, string surname,string mobileNumber, int townID,int roleID)
        {
            UserRepository userrep = new UserRepository();

            //get user with specific username
            User userCheck = userrep.getUserByUsername(username);

            //check if a user with that specific name exists
            //if no user exists, then the user may register with that username
            if (userCheck == null)
            {
                
                //check if email exists
                userCheck = null;
                userCheck = userrep.getUserWithEmail(email);

                //if inputted email does not exist
                if (userCheck == null)
                {
                    Role r = userrep.getRoleById(roleID);

                    User u = new User();
                    u.Username = username;
                    u.Passwords = password;
                    u.Email = email;
                    u.Name = name;
                    u.Surname = surname;
                    u.MobileNumber = mobileNumber.ToString();
                    u.TownID = townID;
                    UserRepository rep = new UserRepository();
                    rep.addUser(u);
                    UserRole rol = new UserRole();
                    rol.Username = username;
                    rol.RoleID = roleID;
                    userrep.SaveUserRole(rol);
                    return regVerifier.RegistrationSuccessful;
                }
                else
                {
                    return regVerifier.EmailExists;
                }

            }
            else
            {
                return regVerifier.UsernameExists;
            }
           
        }


        public Enum loginUser(string username,string password)
        {
            User u = new UserRepository().getUserWithCredentials(username, password);

            //no user exist with that combination of credentials
            if (u == null)
            {
                return loginVerifier.InvalidCredentials;
            }
            else
            {
                return loginVerifier.ValidCredentials;
            }

        }


        public User getUserByUsername(string username)
        {

            return new UserRepository().getUserByUsername(username);
        }
    }
}
