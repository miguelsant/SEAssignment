using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;


namespace DataAccess
{
    public class ProductRepository : ConnectionClass
    {


        public List<Product> getProductsByCategory(int catID)
        {
            List<Product> p = (from prod in MarketplaceEntity.Products
                               where prod.CategoryID == catID
                               select prod).ToList(); 
            return p;

        }


        public List<Product> getSellerProducts(string username)
        {
            List<Product> p = (from prod in MarketplaceEntity.Products
                               where prod.Username == username
                               select prod).ToList();
            return p;
        }

        public List<Category> getAllCategories()
        {
            return (from cat in MarketplaceEntity.Categories
                    select cat).ToList();
        }

        public Category getProductCategory(int id)
        {
            return (from cat in MarketplaceEntity.Categories
                    where cat.CategoryID == id
                    select cat).SingleOrDefault();
        }

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

        public Product getProductByName(string name)
        {
            Product p = (from prod in MarketplaceEntity.Products
                         where prod.ProductName == name
                         select prod).SingleOrDefault();

            return p;
        }

        public void updateProduct(Product prodToUpdate)
        {
            try
            {
                MarketplaceEntity.Products.Attach(getProductByID(prodToUpdate.ProductID));
                MarketplaceEntity.Products.ApplyCurrentValues(prodToUpdate);
                MarketplaceEntity.SaveChanges();
            }
            catch
            {
                MarketplaceEntity.Products.ApplyCurrentValues(prodToUpdate);
                MarketplaceEntity.SaveChanges();
            }

        }

        public void deleteProduct(Product p)
        {
            Product productToDelete = getProductByID(p.ProductID);
            MarketplaceEntity.DeleteObject(productToDelete);
            MarketplaceEntity.SaveChanges();
        }


    }
}
