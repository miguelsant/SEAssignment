using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DataAccess;
namespace BusinessLayer
{
    public class ShoppingCartBL
    {
        public List<ShoppingCart> getUserCarts(string username)
        {
            return new ShoppingCartRepository().getUserCarts(username);
        }

        public void deleteShoppingCart(ShoppingCart c)
        {
            new ShoppingCartRepository().deleteShoppingCart(c);
        }

        public void CreateCart(ShoppingCart x)
        {
             new ShoppingCartRepository().addShoppingCart(x);

        }

        public ShoppingCart getCartsWithUsernameAndID(string username, int id)
        {
            return new ShoppingCartRepository().getShoppingCartByUsernameAndID(username, id);
        }

        public ShoppingCart getCartWithID(int id)
        {
            return new ShoppingCartRepository().getCartWithID(id);
        }

        public List<ShoppingCart> getCartsWithProduct(int id)
        {
            return new ShoppingCartRepository().getCartsWithProduct(id);
        }

        public void updateCart(ShoppingCart c)
        {
            new ShoppingCartRepository().updateShoppingCart(c);
        }
    }
}
