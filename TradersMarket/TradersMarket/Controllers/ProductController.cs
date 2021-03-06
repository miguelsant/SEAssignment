﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradersMarket.Models;
using System.IO;
using Common;
using BusinessLayer;
using TradersMarket.ObserverPattern.Subject;
using TradersMarket.ObserverPattern.Observer;

namespace TradersMarket.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public static int prodID = 0;
        public static string imageURL;
        public static int cartShopID;
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult GetSellerProducts(string username)
        {

            IEnumerable<Product> userprods = new ProductBL().getSellerProducts(username);
            return View(userprods.ToList());

        }
        
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModel mod)
        {

            HttpPostedFileBase file = Request.Files[0];
            string dbPath;
            Random r = new Random();
            int rand = r.Next(1, 100);
            string nameAddition = rand.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Minute.ToString();


            int categoryId = mod.CategoryID;

            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                dbPath = "/Images/" + nameAddition + fileName;
                var path = Path.Combine(Server.MapPath("~/Images/"), nameAddition + fileName);
                file.SaveAs(path);


                Product prod = new Product();
                prod.ProductDescription = mod.prodDescription;
                prod.ProductName = mod.prodName;
                prod.ProductImage = dbPath;
                prod.Quantity = Convert.ToInt32(mod.Quantity);
                prod.Username = Session["Username"].ToString();
                prod.Price = Convert.ToDecimal(mod.Price);
                prod.CategoryID = categoryId;

                new ProductBL().addProduct(prod);

            }


            return View();
        }



        public ActionResult DeleteProduct()
        {
            IEnumerable<Product> allProducts = new ProductBL().getProducts();

            return View("DeleteProductList", allProducts.ToList());

        }



        public ActionResult DeleteSelectedProduct(int id)
        {
            ProductBL bl = new ProductBL();
            Product p = bl.getProductByID(id);

            ShoppingCartBL shopCart = new ShoppingCartBL();

            List<ShoppingCart> carts = shopCart.getCartsWithProduct(p.ProductID);

            if (carts.Count != 0)
            {
                foreach (ShoppingCart c in carts)
                {
                    shopCart.deleteShoppingCart(c);
                }

            }
            bl.deleteProduct(p);
            return RedirectToAction("ManageProducts", "Product");
        }



        public ActionResult displayCategories()
        {

            return View();
        }

        
        public ActionResult displayCategoriesPost()
        {
            string productCategory = Request.Form["CategoryDDL"];

            List<Product> prods = new ProductBL().getProductsByCategory(Convert.ToInt32(productCategory));

            DisplayProductsModel mod = new DisplayProductsModel();
            mod.listProducts = prods;
            return View(mod);
        }

        public ActionResult ProductDetailsShow(int id)
        {
            ProductBL bl = new ProductBL();
            Product p = bl.getProductByID(id);
            UpdateProductModel mod = new UpdateProductModel();
            prodID = id;
            imageURL = p.ProductImage;
            mod.prodID = id.ToString();
            mod.prodName = p.ProductName;
            mod.prodDescription = p.ProductDescription;
            mod.Price = p.Price.ToString();
            mod.ImageURL = p.ProductImage;
            mod.Quantity = p.Quantity.ToString();
            mod.Username = p.Username;
            return View(mod);
        }


        public ActionResult editProductQTY(int productID)
        {
            try
            {
                string username = Session["Username"].ToString();
                ShoppingCart cart = new ShoppingCartBL().getCartsWithUsernameAndID(username, productID);
                ProductQtyModel mod = new ProductQtyModel();
                mod.CartID = cart.ShoppingCartID.ToString();
                mod.Quantity = cart.ProductQuantity.ToString();
                cartShopID = cart.ShoppingCartID;
                return View(mod);
            }
            catch
            {
                return RedirectToAction("Index","Home");
            }


        }

        [HttpPost]
        public ActionResult editProductQTY(ProductQtyModel model)
        {
            


            try
            {
                model.CartID = cartShopID.ToString(); 
                ShoppingCartBL shopbl = new ShoppingCartBL();
                ShoppingCart cart = shopbl.getCartWithID(Convert.ToInt32(model.CartID));
                Product p = new ProductBL().getProductByID(cart.ProductID);

                if (Convert.ToInt32(model.Quantity) == 0)
                {
                    shopbl.deleteShoppingCart(cart);
                }
                else
                {
                    if (Convert.ToInt32(model.Quantity) > 0)
                    {
                        if (p.Quantity >= Convert.ToInt32(model.Quantity))
                        {
                            cart.ProductQuantity = Convert.ToInt32(model.Quantity);
                            shopbl.updateCart(cart);
                        }
                        else
                        {

                        }
                    }
                }

            }
            catch
            {

            }

            return RedirectToAction("displayProductsInCart", "Product");
        }

        public ActionResult displayProductsInCart()
        {
            string username = Session["Username"].ToString();

            List<ShoppingCart> userCarts = new ShoppingCartBL().getUserCarts(username);
            List<Product> products = new List<Product>();



            if (userCarts.Count != 0)
            {
                foreach (ShoppingCart c in userCarts)
                {
                    Product p = new ProductBL().getProductByID(c.ProductID);
                    p.Quantity = c.ProductQuantity;
                    p.Price = p.Price * p.Quantity;
                    products.Add(p);
                }
                return View(products.ToList());
            }
            else
            {
                return RedirectToAction("displayCategories", "Product");
            }

        }



        public ActionResult AddToCart(int id)
        {

            Product p = new ProductBL().getProductByID(id);
            string username = Session["Username"].ToString();

            ShoppingCartBL sbl = new ShoppingCartBL();

            List<ShoppingCart> userCarts = sbl.getUserCarts(username);

            bool productInCart = false;


            if (userCarts.Count != 0)
            {
                foreach (ShoppingCart c in userCarts)
                {
                    if (c.ProductID == id)
                    {
                        if (c.ProductQuantity < p.Quantity)
                        {
                            c.ProductQuantity = c.ProductQuantity + 1;
                            sbl.updateCart(c);
                            productInCart = true;
                            ViewBag.CartResult = "Cart Updated";
                        }
                    }
                }


                if (productInCart == false)
                {
                    ShoppingCart cart = new ShoppingCart();
                    cart.Username = username;
                    cart.ProductID = p.ProductID;
                    cart.ProductQuantity = 1;

                    sbl.CreateCart(cart);
                    ViewBag.CartResult = "Product Added";
                }

                
            }
            else
            {
                ShoppingCart cart = new ShoppingCart();
                cart.Username = username;
                cart.ProductID = p.ProductID;
                cart.ProductQuantity = 1;

                sbl.CreateCart(cart);
                ViewBag.CartResult = "Product Added";

            }


            return View();
        }




        public ActionResult displayProducts()
        {
            IEnumerable<Product> allProducts = new ProductBL().getProducts();

            return View(allProducts.ToList());

        }




        public ActionResult displayProductDetails(int id)
        {
            ProductBL bl = new ProductBL();
            Product p = bl.getProductByID(id);
            UpdateProductModel mod = new UpdateProductModel();
            prodID = id;
            imageURL = p.ProductImage;
            mod.prodID = id.ToString();
            mod.prodName = p.ProductName;
            mod.prodDescription = p.ProductDescription;
            mod.Price = p.Price.ToString();
            mod.ImageURL = p.ProductImage;
            mod.Quantity = p.Quantity.ToString();
            return View(mod);
        }
        

        
        public ActionResult editProduct(int id)
        {
            ProductBL bl = new ProductBL();
            Product p = bl.getProductByID(id);


            UpdateProductModel mod = new UpdateProductModel();
            prodID = id;
            imageURL = p.ProductImage;
            mod.prodID = id.ToString();
            mod.prodName = p.ProductName;
            mod.prodDescription = p.ProductDescription;
            mod.Price = p.Price.ToString();
            mod.ImageURL = p.ProductImage;
            mod.Quantity = p.Quantity.ToString();




            List<Category> cats = new ProductBL().getAllCategories();
            List<SelectListItem> category = new List<SelectListItem>();



            foreach (Category C in cats)
            {
                if (C.CategoryID == p.CategoryID)
                {
                    category.Add(new SelectListItem
                    {
                        Text = C.CategoryName,
                        Value = C.CategoryID.ToString(),
                        Selected = true
                    });
                }
                else
                {
                    category.Add(new SelectListItem
                    {
                        Text = C.CategoryName,
                        Value = C.CategoryID.ToString(),
                    });
                }
            }

            mod.ListCategory = category;


            return View(mod);

        }


        [HttpPost]
        public ActionResult editProduct(UpdateProductModel mod)
        {

            bool picFailed = false;
            string productCategory = Request.Form["CategoryDDL"];
            try
            {
                HttpPostedFileBase file = Request.Files[0];
                string dbPath;
                Random r = new Random();
                int rand = r.Next(1, 100);
                string nameAddition = rand.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Minute.ToString();

                


                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    var fileName = Path.GetFileName(file.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    dbPath = "/Images/" + nameAddition + fileName;
                    var path = Path.Combine(Server.MapPath("~/Images/"), nameAddition + fileName);
                    file.SaveAs(path);


                    Product prod = new Product();
                    prod.ProductID = prodID;
                    prod.ProductDescription = mod.prodDescription;
                    prod.ProductName = mod.prodName;
                    prod.ProductImage = dbPath;
                    prod.Username = Session["Username"].ToString();
                    prod.Price = Convert.ToDecimal(mod.Price);
                    prod.Quantity = Convert.ToInt32(mod.Quantity);
                    prod.CategoryID = Convert.ToInt32(productCategory);
                    new ProductBL().updateProduct(prod);

                }
                else
                {
                    picFailed = true;
                }
            }
            catch
            {
                picFailed = true;
            }


            if (picFailed == true)
            {
                Product prod = new Product();
                prod.ProductID = prodID;
                prod.ProductDescription = mod.prodDescription;
                prod.ProductImage = imageURL;
                prod.ProductName = mod.prodName;
                prod.Username = Session["Username"].ToString();
                prod.Price = Convert.ToDecimal(mod.Price);
                prod.Quantity = Convert.ToInt32(mod.Quantity);
                prod.CategoryID = Convert.ToInt32(productCategory);
                new ProductBL().updateProduct(prod);
            }

            return RedirectToAction("ManageProducts", "Product");


        }

        public ActionResult ManageProducts()
        {

            return View();
        }

    }
}
