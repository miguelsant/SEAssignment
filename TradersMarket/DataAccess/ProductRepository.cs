﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;


namespace DataAccess
{
    public class ProductRepository : ConnectionClass
    {

        

        public void addProduct(Product p)
        {
            MarketplaceEntity.AddToProducts(p);
            MarketplaceEntity.SaveChanges();
        }

        public Product getProductByID(int id)
        {
            Product p = (from prod in MarketplaceEntity.Products
                         where prod.ProductID == id
                         select prod).SingleOrDefault();
            return p;

        }

        public List<Product> getProducts()
        {
            List<Product> p = (from prod in MarketplaceEntity.Products
                               select prod).ToList();
            return p;
        }


        public void updateProduct(Product prodToUpdate)
        {
            MarketplaceEntity.Products.Attach(getProductByID(prodToUpdate.ProductID));
            MarketplaceEntity.Products.ApplyCurrentValues(prodToUpdate);
            MarketplaceEntity.SaveChanges();

        }

        public void deleteProduct(Product p)
        {

            Product productToDelete = getProductByID(p.ProductID);
            MarketplaceEntity.DeleteObject(productToDelete);
            MarketplaceEntity.SaveChanges();
        }


    }
}