using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using seoWebApplication.Data; 
using seoWebApplication.Common;

namespace seoWebApplication.Controllers
{
    public class PCategoryProductController : Controller
    {
        private SeoWebAppEntities db = new SeoWebAppEntities();

        // GET: /PCategoryProduct/
        public ActionResult Index()
        {
            var pcategoryproducts = (from pcat in db.pcategoryproducts.Include(p => p.product).Include(p => p.pcategory) 
                                     join p in db.products on pcat.productFK equals p.product_id
                                     select pcat).ToList();
            return View(pcategoryproducts.ToList());
        }
         

        // GET: /PCategoryProduct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pcategoryproduct pcategoryproduct = db.pcategoryproducts.Find(id);
            if (pcategoryproduct == null)
            {
                return HttpNotFound();
            }
            return View(pcategoryproduct);
        }

        // GET: /PCategoryProduct/Create
        public ActionResult Create()
        {
            var pcategoryFK = (from pcat in db.pcategories where pcat.WebstoreId == Config.IdWebstore select pcat).ToList();
            var products = (from pcat in db.products where pcat.webstore_id == Config.IdWebstore select pcat).ToList();

            ViewBag.productFK = new SelectList(products, "product_id", "name");
            ViewBag.pcategoryFK = new SelectList(pcategoryFK, "Id", "Name");
            return View();
        }

        // POST: /PCategoryProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,pcategoryFK,productFK")] pcategoryproduct pcategoryproduct)
        {
            if (ModelState.IsValid)
            {
                db.pcategoryproducts.Add(pcategoryproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var pcategoryFK = (from pcat in db.pcategories where pcat.WebstoreId == Config.IdWebstore select pcat).ToList();
            var products = (from pcat in db.products where pcat.webstore_id == Config.IdWebstore select pcat).ToList();


            ViewBag.productFK = new SelectList(products, "product_id", "name", pcategoryproduct.productFK);
            ViewBag.pcategoryFK = new SelectList(pcategoryFK, "Id", "Name", pcategoryproduct.pcategoryFK);
            return View(pcategoryproduct);
        }

        // GET: /PCategoryProduct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pcategoryproduct pcategoryproduct = db.pcategoryproducts.Find(id);
            if (pcategoryproduct == null)
            {
                return HttpNotFound();
            }
            var pcategoryFK = (from pcat in db.pcategories where pcat.WebstoreId == Config.IdWebstore select pcat).ToList();
            var products = (from pcat in db.products where pcat.webstore_id == Config.IdWebstore select pcat).ToList();

            ViewBag.productFK = new SelectList(products, "product_id", "name", pcategoryproduct.productFK);
            ViewBag.pcategoryFK = new SelectList(pcategoryFK, "Id", "Name", pcategoryproduct.pcategoryFK);
            return View(pcategoryproduct);
        }

        // POST: /PCategoryProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,pcategoryFK,productFK")] pcategoryproduct pcategoryproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pcategoryproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var pcategoryFK = (from pcat in db.pcategories where pcat.WebstoreId == Config.IdWebstore select pcat).ToList();
            var products = (from pcat in db.products where pcat.webstore_id == Config.IdWebstore select pcat).ToList();

            ViewBag.productFK = new SelectList(products, "product_id", "name", pcategoryproduct.productFK);
            ViewBag.pcategoryFK = new SelectList(pcategoryFK, "Id", "Name", pcategoryproduct.pcategoryFK);
            return View(pcategoryproduct);
        }

        // GET: /PCategoryProduct/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pcategoryproduct pcategoryproduct = db.pcategoryproducts.Find(id);
            if (pcategoryproduct == null)
            {
                return HttpNotFound();
            }
            return View(pcategoryproduct);
        }

        // POST: /PCategoryProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pcategoryproduct pcategoryproduct = db.pcategoryproducts.Find(id);
            db.pcategoryproducts.Remove(pcategoryproduct);
            db.SaveChanges();
            return RedirectToAction("Index");
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
