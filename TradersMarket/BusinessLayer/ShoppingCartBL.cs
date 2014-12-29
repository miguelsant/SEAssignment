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

        public void CreateCart(ShoppingCart x)
        {
             new ShoppingCartRepository().addShoppingCart(x);

        }

        public void updateCart(ShoppingCart c)
        {
            new ShoppingCartRepository().updateShoppingCart(c);
        }
    }
}
