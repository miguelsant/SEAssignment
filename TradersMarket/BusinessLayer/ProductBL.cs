﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using Common;

namespace BusinessLayer
{
    public class ProductBL
    {
        public void addProduct(Product p)
        {
            new ProductRepository().addProduct(p);
        }

        public void deleteProduct(Product p)
        {
            new ProductRepository().deleteProduct(p);

        }

        public void updateProduct(Product p)
        {
            new ProductRepository().updateProduct(p);

        }

        public IEnumerable<Product> getProducts()
        {
            IEnumerable<Product> prods = new ProductRepository().getProducts();
            return prods;
        }

        public Product getProductByID(int id)
        {

            return new ProductRepository().getProductByID(id);
        }


    }
}