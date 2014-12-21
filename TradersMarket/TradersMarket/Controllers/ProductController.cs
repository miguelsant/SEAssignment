using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradersMarket.Models;
using System.IO;
using Common;
using BusinessLayer;

namespace TradersMarket.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public static int prodID = 0;
        public static string imageURL;
        public ActionResult Index()
        {
            return View();
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
                prod.Username = Session["Username"].ToString();
                prod.Price = Convert.ToDecimal(mod.Price);

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
            bl.deleteProduct(p);
            return RedirectToAction("DeleteProduct","Product");
        }

        public ActionResult displayProducts()
        {
            IEnumerable<Product> allProducts = new ProductBL().getProducts();

            return View(allProducts.ToList());

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

            return View(mod);

        }


        [HttpPost]
        public ActionResult editProduct(UpdateProductModel mod)
        {

            bool picFailed = false;
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

                new ProductBL().updateProduct(prod);
            }

            return RedirectToAction("editProduct", "Product");


        }

        public ActionResult ManageProducts()
        {

            return View();
        }

    }
}
