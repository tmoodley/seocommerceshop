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
    public class PCategoryController : Controller
    {
        private SeoWebAppEntities db = new SeoWebAppEntities();

        // GET: /PCategory/
        public ActionResult Index()
        {
            var pcategories = (from pcat in db.pcategories.Include(p => p.pcategory2) where pcat.WebstoreId == Config.IdWebstore select pcat).ToList();
            return View(pcategories.ToList());
        }

        public ActionResult GetPCategories()
        {
             
            var pcategories = (from pcat in db.pcategories where pcat.WebstoreId == Config.IdWebstore select new { pcat.Id, pcat.Name, pcat.Description }).ToList();
            //return Json(pcategories.ToList(), JsonRequestBehavior.AllowGet);
            return Json(new
            {
                aaData = Json(pcategories).Data
            },
                "application/json", JsonRequestBehavior.AllowGet);
        }

        // GET: /PCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pcategory pcategory = db.pcategories.Find(id);
            if (pcategory == null)
            {
                return HttpNotFound();
            }
            return View(pcategory);
        }

        // GET: /PCategory/Create
        public ActionResult Create()
        {
            var pcategories = (from pcat in db.pcategories.Include(p => p.pcategory2) where pcat.WebstoreId == Config.IdWebstore || pcat.WebstoreId == 1 select pcat).ToList();
            ViewBag.ParentId = new SelectList(pcategories, "Id", "Name");
            ViewBag.Webstore = Config.IdWebstore;
            return View();
        }

        // POST: /PCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ParentId,Name,Description,WebstoreId")] pcategory pcategory)
        {
            if (ModelState.IsValid)
            {
                db.pcategories.Add(pcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentId = new SelectList(db.pcategories, "Id", "Name", pcategory.ParentId);
            return View(pcategory);
        }

        // GET: /PCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pcategory pcategory = db.pcategories.Find(id);
            if (pcategory == null)
            {
                return HttpNotFound();
            }
            var pcategories = (from pcat in db.pcategories.Include(p => p.pcategory2) where pcat.WebstoreId == Config.IdWebstore || pcat.WebstoreId == 1 select pcat).ToList();

            ViewBag.ParentId = new SelectList(pcategories, "Id", "Name", pcategory.ParentId);
            return View(pcategory);
        }

        // POST: /PCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ParentId,Name,Description,WebstoreId")] pcategory pcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var pcategories = (from pcat in db.pcategories.Include(p => p.pcategory2) where pcat.WebstoreId == Config.IdWebstore || pcat.WebstoreId == 1 select pcat).ToList();
            ViewBag.ParentId = new SelectList(pcategories, "Id", "Name", pcategory.ParentId);
            return View(pcategory);
        }

        // GET: /PCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pcategory pcategory = db.pcategories.Find(id);
            if (pcategory == null)
            {
                return HttpNotFound();
            }
            return View(pcategory);
        }

        // POST: /PCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pcategory pcategory = db.pcategories.Find(id);
            db.pcategories.Remove(pcategory);
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
