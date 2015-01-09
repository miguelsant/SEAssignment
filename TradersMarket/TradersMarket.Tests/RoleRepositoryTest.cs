using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Common;
using System.Collections.Generic;
using Common;
using DataAccess;
using System.Linq;
namespace TradersMarket.Tests
{
    
    
    /// <summary>
    ///This is a test class for RoleRepositoryTest and is intended
    ///to contain all RoleRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RoleRepositoryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion





        TradersMarketplaceDBEntities marketPlaceEntity = new TradersMarketplaceDBEntities();
        List<Role> allExpectedRoles = new List<Role>();
        List<Role> cleanupList = new List<Role>();
        [TestInitialize]
        public void InitializeTest()
        {
            allExpectedRoles = marketPlaceEntity.Roles.ToList();
            

        }






        //Addroles testing here
        #region
        /// <summary>
        ///A test for addRole
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void addRoleWithNullTest()
        {

                RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
                string roleName = null;
                target.addRole(roleName);

        }


        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void addRoleWithStringEmptyTest()
        {

            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            string roleName = string.Empty;
            target.addRole(roleName);

        }



        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void addRoleWith1CharacterTest()
        {

            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            string roleName = "r";
            target.addRole(roleName);
            
        }


        [TestMethod()]
        public void addRoleWith49CharacterTest()
        {

            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            string roleName = "rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr";
            int createdRoleID = target.addRole(roleName);
            Role r = marketPlaceEntity.Roles.Single(x => x.RoleID == createdRoleID);
            cleanupList.Add(r);
            Assert.IsNotNull(r);
        }


        [TestMethod()]
        public void addRoleWith50CharacterTest()
        {

            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            string roleName = "rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr";
            int createdRoleID = target.addRole(roleName);
            Role r = marketPlaceEntity.Roles.Single(x => x.RoleID == createdRoleID);
            cleanupList.Add(r);
            Assert.IsNotNull(r);
        }


        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void addRoleWithSpecialCharactersTest()
        {

            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            string roleName = "$admnistrator$";
            target.addRole(roleName);
            
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void addRoleWith51CharactersTest()
        {

            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            string roleName = "rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr";
            target.addRole(roleName);

        }

        #endregion


        #region
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetRoleWithNegativeTest()
        {
            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            //Role r = new Role(); // TODO: Initialize to an appropriate value
            //r.RoleName = "GetTest";
            //r.RoleID = -1;
            target.getRoleByID(-1);
        }


        [TestMethod()]
        public void GetRoleWithExistingIDTest()
        {
            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            Role r = new Role(); // TODO: Initialize to an appropriate value

            Role actual = target.getRoleByID(1);
            Role expected = marketPlaceEntity.Roles.SingleOrDefault(x => x.RoleID == 1);

            Assert.AreEqual(expected.RoleID, actual.RoleID);
        }


        [TestMethod()]
        public void GetRoleWithNonExistingTest()
        {
            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            Role r = new Role(); // TODO: Initialize to an appropriate value

            Role actual = target.getRoleByID(5786);
            Role expected = marketPlaceEntity.Roles.SingleOrDefault(x => x.RoleID == 5786);

            Assert.IsNull(actual);
            Assert.IsNull(expected);
        }



        #endregion


        #region
        /// <summary>
        ///A test for UpdateRole
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdateRoleNullTest()
        {
            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            Role r = new Role(); // TODO: Initialize to an appropriate value
            target.UpdateRole(r);
        }


        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void UpdateRoleWithStringEmptyTest()
        {

            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            Role r = new Role();
            r.RoleName = "TestingUpdate";
            marketPlaceEntity.AddToRoles(r);
            marketPlaceEntity.SaveChanges();
            cleanupList.Add(r);
            r.RoleName = string.Empty;
            target.UpdateRole(r);

            
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UpdateRoleWith1CharacterTest()
        {

            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            Role r = new Role();
            r.RoleName = "TestingUpdate";
            marketPlaceEntity.AddToRoles(r);
            marketPlaceEntity.SaveChanges();
            cleanupList.Add(r);
            r.RoleName = "a";
            target.UpdateRole(r);


            
        }

        [TestMethod()]
        public void UpdateRoleWith49CharacterTest()
        {

            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            Role r = new Role();

            //Create new role and save to database
            Random rand = new Random();
            int random = rand.Next(100, 1230);
            r.RoleName = "TestingUpdate" + random;
            string NotExpectedName = r.RoleName;
            marketPlaceEntity.AddToRoles(r);
            marketPlaceEntity.SaveChanges();

            //Get newly created role with name given
            Role roleToUpdate = marketPlaceEntity.Roles.SingleOrDefault(x => x.RoleName == r.RoleName);

            //Change the name of the created role
            roleToUpdate.RoleName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            //Test the update method in the repository and get its ID
            int updatedRoleID = target.UpdateRole(roleToUpdate);

            //Get the supposedey updated role from the database with the role id
            Role updatedRole = marketPlaceEntity.Roles.SingleOrDefault(x => x.RoleID == updatedRoleID);
            cleanupList.Add(updatedRole);
            //check if role was actually updated
            Assert.AreNotEqual(NotExpectedName, updatedRole.RoleName);


        }



        [TestMethod()]
        public void UpdateRoleWith50CharacterTest()
        {

            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            Role r = new Role();

            //Create new role and save to database
            Random rand = new Random();
            int random = rand.Next(100, 1230);
            r.RoleName = "TestingUpdate" + random;
            string NotExpectedName = r.RoleName;
            marketPlaceEntity.AddToRoles(r);
            marketPlaceEntity.SaveChanges();

            //Get newly created role with name given
            Role roleToUpdate = marketPlaceEntity.Roles.SingleOrDefault(x => x.RoleName == r.RoleName);

            //Change the name of the created role
            roleToUpdate.RoleName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            //Test the update method in the repository and get its ID
            int updatedRoleID = target.UpdateRole(roleToUpdate);

            //Get the supposedey updated role from the database with the role id
            Role updatedRole = marketPlaceEntity.Roles.SingleOrDefault(x => x.RoleID == updatedRoleID);
            cleanupList.Add(updatedRole);
            //check if role was actually updated
            Assert.AreNotEqual(NotExpectedName, updatedRole.RoleName);


        }


        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UpdateRoleWithNonSpecialCharacterTest()
        {

            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            Role r = new Role();

            //Create new role and save to database
            Random rand = new Random();
            int random = rand.Next(100, 1230);
            r.RoleName = "TestingUpdate" + random;
            string NotExpectedName = r.RoleName;
            marketPlaceEntity.AddToRoles(r);
            marketPlaceEntity.SaveChanges();

            //Get newly created role with name given
            Role roleToUpdate = marketPlaceEntity.Roles.SingleOrDefault(x => x.RoleName == r.RoleName);
            cleanupList.Add(r);
            //Change the name of the created role
            roleToUpdate.RoleName = "$admin$";
            target.UpdateRole(roleToUpdate);
           

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UpdateRoleWith51CharacterTest()
        {

            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            Role r = new Role();

            //Create new role and save to database
            Random rand = new Random();
            int random = rand.Next(100, 1230);
            r.RoleName = "TestingUpdate" + random;
            string NotExpectedName = r.RoleName;
            marketPlaceEntity.AddToRoles(r);
            marketPlaceEntity.SaveChanges();

            //Get newly created role with name given
            Role roleToUpdate = marketPlaceEntity.Roles.SingleOrDefault(x => x.RoleName == r.RoleName);

            //Change the name of the created role
            roleToUpdate.RoleName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            cleanupList.Add(roleToUpdate);
            //Test the update method in the repository and get its ID
            target.UpdateRole(roleToUpdate);


        }
        #endregion
        /// <summary>
        ///A test for DeleteRole
        ///</summary>
        //[TestMethod()]
        public void DeleteRoleTest()
        {
            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            Role r = null; // TODO: Initialize to an appropriate value
            target.DeleteRole(r);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }







        #region
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteRoleWithNegativeTest()
        {
            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.RoleName = "GetTest";
            r.RoleID = -1;
            target.DeleteRole(r);
        }


        [TestMethod()]
        public void DeleteRoleWithExistingIDTest()
        {
            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            Role r = new Role(); // TODO: Initialize to an appropriate value
            Random rand = new Random();
            int random = rand.Next(100,1000);
            r.RoleName = "DeleteTest" + random;
            marketPlaceEntity.AddToRoles(r);
            marketPlaceEntity.SaveChanges();
            //cleanupList.Add(r);

            Role actualToDelete = marketPlaceEntity.Roles.SingleOrDefault(x => x.RoleName == r.RoleName);
            target.DeleteRole(actualToDelete);

            Role expectedDeleted = marketPlaceEntity.Roles.SingleOrDefault(x => x.RoleID == actualToDelete.RoleID);

            Assert.IsNull(expectedDeleted);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteRoleWithNonExistingIDTest()
        {
            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.RoleID = 10000;
            r.RoleName = "TestDeleteNon";

            target.DeleteRole(r);
        }



        #endregion













        [TestCleanup]
        public void FinilizeTests()
        {
            foreach (Role r in cleanupList)
            {
                try
                {
                    marketPlaceEntity.DeleteObject(r);
                    marketPlaceEntity.SaveChanges();
                }
                catch
                {

                }

            }
        }



        /// <summary>
        ///A test for getRoleByName
        ///</summary>
        //[TestMethod()]
        public void getRoleByNameTest()
        {
            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
            string rolename = string.Empty; // TODO: Initialize to an appropriate value
            Role expected = null; // TODO: Initialize to an appropriate value
            Role actual;
            actual = target.getRoleByName(rolename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for getRoleByName
        ///</summary>
        //[TestMethod()]
        public void getRoleByIDTest()
        {
            RoleRepository target = new RoleRepository(); // TODO: Initialize to an appropriate value
        }

        public void AreListsEqual(List<Role> expected, List<Role> actual)
        {
            int listLength = actual.Count;
            listLength = listLength - 1;
            for (int i = 0; i < listLength; i++)
            {
                Assert.AreEqual(expected.ElementAt(i).RoleID, actual.ElementAt(i).RoleID, "1 or more items do not match");
                //  CollectionAssert.AreEqual(expected, actual, "1 or more items do not match");
            }
        }

        public void AreListsEqualName(List<Role> expected, List<Role> actual)
        {
            int listLength = actual.Count;
            listLength = listLength - 1;
            for (int i = 0; i < listLength; i++)
            {
                Assert.AreNotEqual(expected.ElementAt(i).RoleName, actual.ElementAt(i).RoleName, "1 or more items do not match");
                //  CollectionAssert.AreEqual(expected, actual, "1 or more items do not match");
            }
        }

    }
}
