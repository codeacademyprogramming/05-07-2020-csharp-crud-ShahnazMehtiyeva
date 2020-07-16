using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Context;
using Task.Models;

namespace Task.Controllers
{
    public class ProductController : Controller
    {
        readonly ProductContext db = new ProductContext();
        // GET: Product
        public ActionResult Index()
        {
            var products = db.Products.ToList();
            return View(products);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            return View(db.Products.Where(x => x.Name.Contains(search)).ToList());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name, string description, decimal price)
        {
            Product product = new Product()
            {
                Name = name,
                Description = description,
                Price = price
            };
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetUser(int id)
        {
            var user = db.Products.FirstOrDefault(x => x.Id == id);
            return View(user);
        }
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(400);
            }
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return new HttpStatusCodeResult(400);
            }

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var user_ = db.Products.FirstOrDefault(x => x.Id == product.Id);
                if (user_ == null)
                {
                    return new HttpStatusCodeResult(400);
                }

                db.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return new HttpStatusCodeResult(400);
        }

        public ActionResult Delete()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(400);
            }
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return new HttpStatusCodeResult(400);
            }

            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}