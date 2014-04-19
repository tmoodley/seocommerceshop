using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using seoWebApplication.Data;

namespace seoWebApplication.api
{
    public class SocialMediaController : Controller
    {
        private SeoWebAppEntities db = new SeoWebAppEntities();

        // GET: /SocialMedia/
        public ActionResult Index()
        {
            return View(db.SocialMedias.ToList());
        }

        // GET: /SocialMedia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia socialmedia = db.SocialMedias.Find(id);
            if (socialmedia == null)
            {
                return HttpNotFound();
            }
            return View(socialmedia);
        }

        // GET: /SocialMedia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SocialMedia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,WebstoreId,Facebook,Twitter,Google,LinkedIn,AddThis")] SocialMedia socialmedia)
        {
            if (ModelState.IsValid)
            {
                db.SocialMedias.Add(socialmedia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socialmedia);
        }

        // GET: /SocialMedia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia socialmedia = db.SocialMedias.Find(id);
            if (socialmedia == null)
            {
                return HttpNotFound();
            }
            return View(socialmedia);
        }

        // POST: /SocialMedia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,WebstoreId,Facebook,Twitter,Google,LinkedIn,AddThis")] SocialMedia socialmedia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialmedia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialmedia);
        }

        // GET: /SocialMedia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia socialmedia = db.SocialMedias.Find(id);
            if (socialmedia == null)
            {
                return HttpNotFound();
            }
            return View(socialmedia);
        }

        // POST: /SocialMedia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialMedia socialmedia = db.SocialMedias.Find(id);
            db.SocialMedias.Remove(socialmedia);
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
