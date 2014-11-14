using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Catalog1.Models;
using System.Collections.Generic;
using System.Net;

namespace Catalog1.Controllers
{
    public class ProductController : Controller
    {
        WidgetModel db = new WidgetModel();

        // GET: Product
        public ActionResult Index()
        {
            ViewBag.UserName = "Lord User";

            var products = db.Products;

            foreach (Product product in products)
            {
                product.Price -= Decimal.Round(product.Price * product.PriceModifier, 2);
            }

            return View(products);
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //RedirectToAction("Index");
            }
            Product product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        public ActionResult ShoppingCart(int? productID, int amount = 0)
        {
            if (productID != null)
            {
                Product product = db.Products.Find(productID);
                product.Quantity -= amount;

                if (db.CartItems.Where(q => q.Name == product.Name)
                    .Count() > 0)
                {
                    db.CartItems.Where(q => q.Name == product.Name)
                        .First().Quantity += amount;
                }
                else
                {
                    var cartItem = new CartItem()
                    {
                        Name = product.Name,
                        Quantity = amount,
                        Price = product.Price
                    };
                    db.CartItems.Add(cartItem);
                }
                db.SaveChanges();
            }
            var cart = new Cart()
            {
                Carts = db.CartItems.ToList()
            };

            ViewBag.PriceTotal = cart.PriceTotal;
            
            return View(db.CartItems.ToList());
        }

        //[HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}