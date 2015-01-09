using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Text.RegularExpressions;

namespace DataAccess
{
    public class RoleRepository : ConnectionClass
    {
        public List<Role> getAllRoles()
        {
            return (from roles in MarketplaceEntity.Roles
                    select roles).ToList();

        }

        public Role getRoleByName(string rolename)
        {
            return (from role in MarketplaceEntity.Roles
                    where role.RoleName == rolename
                    select role).SingleOrDefault();
        }


        public Role getRoleByID(int id)
        {

            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be less than 1");
            }


            return (from role in MarketplaceEntity.Roles
                    where role.RoleID == id
                    select role).SingleOrDefault();
        }

        //public void addRole(string roleName)
        //{
        //    Role r = new Role();
        //    r.RoleName = roleName;
        //    if (r.RoleName != string.Empty)
        //    {
        //        if (r.RoleName.Length < 51 && r.RoleName.Length > 4)
        //        {
        //            if(Regex.IsMatch(r.RoleName, @"^[a-zA-Z]+$") == true)
        //            {
        //            MarketplaceEntity.AddToRoles(r);
        //            MarketplaceEntity.SaveChanges();
        //            }
        //            else
        //            {
        //                throw new Exception("Role name must be between 4 and 50");
        //            }
        //        }
        //        else
        //        {
        //            throw new ArgumentOutOfRangeException("Role name must be between 4 and 50");
        //        }
        //    }
        //    else
        //    {
        //        throw new NullReferenceException("Name cannot be empty");
        //    }
        //}



        public int addRole(string roleName)
        {
            if (roleName != null)
            {

            }
            else
            {
                throw new NullReferenceException("Name cannot be null");
            }


            if (roleName != string.Empty)
            {

            }
            else
            {
                throw new Exception("Name cannot be empty");
            }

            if (roleName.Length < 4)
            {
                throw new ArgumentOutOfRangeException("Name length cannot be less than o4ne");
            }
            else
            {
                
            }


            if (roleName.Length <= 50)
            {

            }
            else
            {
                throw new ArgumentOutOfRangeException("Name length cannot be more than 50");
            }

            if (Regex.IsMatch(roleName, @"^[a-zA-Z]+$") == true)
            {


            }
            else
            {
                throw new FormatException("Only characters from A to Z can be inputted");
            }


            Role r = new Role();
            r.RoleName = roleName;
            MarketplaceEntity.AddToRoles(r);
            MarketplaceEntity.SaveChanges();
            return r.RoleID;

        }


        public void DeleteRole(Role r)
        {
            if (r.RoleID > 0)
            {

            }
            else
            {
                throw new ArgumentOutOfRangeException("Role Id Cannot be negative");
            }

            if (MarketplaceEntity.Roles.SingleOrDefault(x => x.RoleID == r.RoleID) == null)
            {
                throw new ArgumentNullException("Role ID does not exist");
            }


                Role rol = MarketplaceEntity.Roles.SingleOrDefault(x => x.RoleID == r.RoleID);
                MarketplaceEntity.DeleteObject(rol);
                MarketplaceEntity.SaveChanges();

            

        }


        public int UpdateRole(Role r)
        {
            if (r.RoleName == null)
            {
                throw new NullReferenceException("Role cannot be null");
            }

            if (r.RoleName == string.Empty)
            {
                throw new Exception("Name cannot be empty");
            }

            if (r.RoleName.Length < 4)
            {
                throw new ArgumentOutOfRangeException("Name length cannot be less than o4ne");
            }
            else
            {

            }


            if (r.RoleName.Length <= 50)
            {

            }
            else
            {
                throw new ArgumentOutOfRangeException("Name length cannot be more than 50");
            }

            if (Regex.IsMatch(r.RoleName, @"^[a-zA-Z]+$") == true)
            {


            }
            else
            {
                throw new FormatException("Only characters from A to Z can be inputted");
            }


            MarketplaceEntity.Roles.Attach(getRoleByID(r.RoleID));
            MarketplaceEntity.Roles.ApplyCurrentValues(r);
            MarketplaceEntity.SaveChanges();
            return r.RoleID;
        }

    }
}
