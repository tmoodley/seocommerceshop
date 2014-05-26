using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using seoWebApplication.Data;

namespace seoWebApplication.Controllers
{
    public class PictureController : Controller
    {
        private SeoWebAppEntities db = new SeoWebAppEntities();

        // GET: /Picture/
        public ActionResult Index()
        {
            var pictures = db.Pictures.Include(p => p.product);
            return View(pictures.ToList());
        }

        // GET: /Picture/Product/5
        public ActionResult Product(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // GET: /Picture/Products/5
        public ActionResult Products(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var picture = (from p in db.Pictures where p.ProductFK == id select p).ToList();
            if (picture == null)
            {
                return HttpNotFound();
            }
            return PartialView(picture);
        }

        // GET: /Picture/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // GET: /Picture/Create
        public ActionResult Create(int? Id)
        { 
            ViewBag.Id = Id;
            return PartialView();
        }

        // POST: /Picture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Url,Alt,Description,ProductFK")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                picture.Url = "/productimages/" + picture.Url;
                db.Pictures.Add(picture);
                db.SaveChanges();
                return Redirect("/admin/catalog/products.aspx");
            }

            ViewBag.ProductFK = new SelectList(db.products, "product_id", "name", picture.ProductFK);
            return PartialView(picture);
        }

        // GET: /Picture/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductFK = new SelectList(db.products, "product_id", "name", picture.ProductFK);
            return PartialView(picture);
        }

        // POST: /Picture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Url,Alt,Description,ProductFK")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(picture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductFK = new SelectList(db.products, "product_id", "name", picture.ProductFK);
            return PartialView(picture);
        }

        // GET: /Picture/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return PartialView(picture);
        }

        // POST: /Picture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Picture picture = db.Pictures.Find(id);
            db.Pictures.Remove(picture);
            db.SaveChanges();
            return Redirect("/admin/catalog/products.aspx");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
