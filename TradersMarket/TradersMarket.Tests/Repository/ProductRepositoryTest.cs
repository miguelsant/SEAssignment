﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using TradersMarket;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using Common;

namespace TradersMarket.Tests.Repository
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void CreateProduct()
        {
            ProductRepository prodRep = new ProductRepository();
            
            List<Category> cats = prodRep.getAllCategories();
            List<User> getallUser = new UserRepository().getAllUsers();
            Product p = new Product();
             
            Random r = new Random();
            int random = r.Next(1,1000);
            p.CategoryID = cats[1].CategoryID;
            p.Price = 50;
            p.ProductName = "testproduct" + random;
            p.Quantity = 5;
            p.Username = getallUser[1].Username;
            p.ProductImage = @"/Images/default.jpg";
            p.ProductDescription = "test description";

            prodRep.addProduct(p);
            Product addedP = prodRep.getProductByName(p.ProductName);
            Assert.IsNotNull(addedP);
            
        }

        [TestMethod]
        public void EditProduct()
        {
            //First i need to create a product to edit
            ProductRepository prodRep = new ProductRepository();

            List<Category> cats = prodRep.getAllCategories();
            List<User> getallUser = new UserRepository().getAllUsers();
            Product p = new Product();

            Random r = new Random();
            int random = r.Next(1, 1000);
            p.CategoryID = cats[1].CategoryID;
            p.Price = 50;
            p.ProductName = "testproduct" + random;
            p.Quantity = 5;
            p.Username = getallUser[1].Username;
            p.ProductImage = @"/Images/default.jpg";
            p.ProductDescription = "test description";

            prodRep.addProduct(p);
            Product addedP = prodRep.getProductByName(p.ProductName);
            //-------------------------------------------------------------------------------

            Random r2 = new Random();
            int rand = r2.Next(1001, 2000);

            //I will now update this product

            addedP.ProductName = "testing" + rand;
            prodRep.updateProduct(addedP);
            Product editedP = prodRep.getProductByName(addedP.ProductName);
            Assert.IsNotNull(editedP);

            //--------------------------------------------------------------------------------
            //Delete product once created so that they dont clutter website
            prodRep.deleteProduct(addedP);

        }


        [TestMethod]
        public void DeleteProduct()
        {
            //First i need to create a product to delete
            ProductRepository prodRep = new ProductRepository();

            List<Category> cats = prodRep.getAllCategories();
            List<User> getallUser = new UserRepository().getAllUsers();
            Product p = new Product();

            Random r = new Random();
            int random = r.Next(1, 1000);
            p.CategoryID = cats[1].CategoryID;
            p.Price = 50;
            p.ProductName = "testproduct" + random;
            p.Quantity = 5;
            p.Username = getallUser[1].Username;
            p.ProductImage = @"/Images/default.jpg";
            p.ProductDescription = "test description";

            prodRep.addProduct(p);
            Product addedP = prodRep.getProductByName(p.ProductName);
            //-------------------------------------------------------------------------------
            //Delete the added product
            prodRep.deleteProduct(addedP);
            Product deletedProd = prodRep.getProductByName(p.ProductName);
            Assert.IsNull(deletedProd);

        }

        [TestMethod]
        public void ListProduct()
        {
            //First i need to create a product to get and list
            ProductRepository prodRep = new ProductRepository();

            List<Category> cats = prodRep.getAllCategories();
            List<User> getallUser = new UserRepository().getAllUsers();
            Product p = new Product();

            Random r = new Random();
            int random = r.Next(1, 1000);
            p.CategoryID = cats[1].CategoryID;
            p.Price = 50;
            p.ProductName = "testproduct" + random;
            p.Quantity = 5;
            p.Username = getallUser[1].Username;
            p.ProductImage = @"/Images/default.jpg";
            p.ProductDescription = "test description";

            prodRep.addProduct(p);
            //-------------------------------------------------------------------------------

            Product productAdded = prodRep.getProductByName(p.ProductName);
            Assert.IsNotNull(productAdded);
        }


    }
}
