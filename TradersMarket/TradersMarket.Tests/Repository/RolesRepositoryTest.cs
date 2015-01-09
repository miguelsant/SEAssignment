using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using DataAccess;
namespace TradersMarket.Tests.Repository
{
    [TestClass]
    public class RolesRepositoryTest
    {

        TradersMarketplaceDBEntities marketPlaceEntity = new TradersMarketplaceDBEntities();
        List<Role> allExpectedRoles = new List<Role>();

        [TestInitialize]
        public void InitializeTest()
        {
            allExpectedRoles = marketPlaceEntity.Roles.ToList();

        }


        //---------------------------------------------------------------------------->
        //Equivalence Testing



        /// <summary>
        /// Try to add a role, should receive null reference exception due to role name stirng being empty
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CreateRoleTest2()
        {
            RoleRepository roleRep = new RoleRepository();
            Role r = new Role();
            r.RoleName = "";

            try
            {
               // roleRep.addRole(r);
            }
            catch
            {

                throw;
            }


        }


        /// <summary>
        /// This role test creates an actual role. No exception are expected.
        /// </summary>
        [TestMethod]
        public void CreateRoleTest1()
        {
            RoleRepository roleRep = new RoleRepository();
            Role r = new Role();
            Guid guid = Guid.NewGuid();
            r.RoleName = "RoleTest";

            //Add role to current list to compare
            allExpectedRoles.Add(r);

            //ADD role to database
            //roleRep.addRole(r);

            AreListsEqual(allExpectedRoles, marketPlaceEntity.Roles.ToList());
            
        }





        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateRoleTest3()
        {
            RoleRepository roleRep = new RoleRepository();
            Role r = new Role();
            r.RoleName = "12";

            try
            {
                //roleRep.addRole(r);
            }
            catch
            {

                throw;
            }

        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateRoleTest4()
        {
            RoleRepository roleRep = new RoleRepository();
            Role r = new Role();
            r.RoleName = "RoleTest$£";

            try
            {
                //roleRep.addRole(r);
            }
            catch
            {

                throw;
            }

        }
        //--------------------------------------------------------------


        [TestMethod]
        public void GetRoles()
        {
            RoleRepository roleRep = new RoleRepository();
            List<Role> allExpectedR = new List<Role>();
            List<Role> allActual = new List<Role>();
            allExpectedR = marketPlaceEntity.Roles.ToList();
            allActual = roleRep.getAllRoles();

            AreListsEqual(allExpectedRoles, allActual);
        }

        //---------------------------------------------------------------
        [TestMethod]
        public void GetRoleByIDValid()
        {
            RoleRepository roleRep = new RoleRepository();
            Role rExpected = marketPlaceEntity.Roles.SingleOrDefault(x => x.RoleID == 1);
            Role rActual = roleRep.getRoleByID(rExpected.RoleID);

            Assert.AreEqual(rExpected.RoleID, rActual.RoleID);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetRoleByIDInvalid()
        {
            RoleRepository roleRep = new RoleRepository();
            try
            {
                Role rExpected = marketPlaceEntity.Roles.SingleOrDefault(x => x.RoleID == 017283);
                Role rActual = roleRep.getRoleByID(rExpected.RoleID);
            }
            catch
            {
                throw;
            }

            

        }







        public void EditRoleTest1()
        {


        }

        public void EditRoleTest2()
        {


        }

        public void EditRoleTest3()
        {


        }

        public void EditRoleTest4()
        {


        }

        public void DeleteRoleTest1()
        {

        }

        public void DeleteRoleTest2()
        {

        }

        public void DeleteRoleTest3()
        {

        }

        public void DeleteRoleTest4()
        {

        }




        public void AreListsEqual(List<Role> expected, List<Role> actual)
        {
            int listLength = actual.Count;
            listLength = listLength - 1;
            for (int i = 0; i < listLength ; i++)
            {
                Assert.AreEqual(expected.ElementAt(i).RoleID, actual.ElementAt(i).RoleID,"1 or more items do not match");
              //  CollectionAssert.AreEqual(expected, actual, "1 or more items do not match");
            }
        }

    }
}
