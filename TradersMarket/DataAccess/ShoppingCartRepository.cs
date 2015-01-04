using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class ShoppingCartRepository : ConnectionClass
    {


        public List<ShoppingCart> getCartsWithProduct(int id)
        {
            return (from carts in MarketplaceEntity.ShoppingCarts
                    where carts.ProductID == id
                    select carts).ToList();
        }

        public List<ShoppingCart> getUserCarts(string username)
        {
            return (from carts in MarketplaceEntity.ShoppingCarts
                    where carts.Username == username
                    select carts).ToList();

        }

        public void addShoppingCart(ShoppingCart c)
        {
            MarketplaceEntity.AddToShoppingCarts(c);
            MarketplaceEntity.SaveChanges();
        }


        public ShoppingCart getShoppingCartByUsernameAndID(string username, int prodID)
        {
            return (from carts in MarketplaceEntity.ShoppingCarts
                    where carts.Username == username && carts.ProductID == prodID
                    select carts).SingleOrDefault();

        }

        public ShoppingCart getCartWithID(int id)
        {
            return (from carts in MarketplaceEntity.ShoppingCarts
                    where carts.ShoppingCartID == id
                    select carts).SingleOrDefault();

        }


        public void deleteShoppingCart(ShoppingCart c)
        {
            ShoppingCart cartToDelete = getCartWithID(c.ShoppingCartID);
            MarketplaceEntity.DeleteObject(cartToDelete);
            MarketplaceEntity.SaveChanges();
        }

        public void updateShoppingCart(ShoppingCart c)
        {
            
            MarketplaceEntity.ShoppingCarts.Attach(getCartWithID(c.ShoppingCartID));
            MarketplaceEntity.ShoppingCarts.ApplyCurrentValues(c);
            MarketplaceEntity.SaveChanges();

        }
    }
}
