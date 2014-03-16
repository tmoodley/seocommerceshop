using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using seoWebApplication.Data;

namespace seoWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private SeoWebAppEntities db = new SeoWebAppEntities();
        // GET: /Home/
        public ActionResult Index()
        {
            return Redirect("default.aspx");  
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact([Bind(Include = "Id,FirstName,LastName,CellPhone,CompanyName,Comments,Email,EnteredOn")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }
	}
}