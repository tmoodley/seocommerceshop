using System.Web.Mvc;
namespace seoWebApplication.Controllers
{
    public class ViewBindRouteController : Controller
    {
        /// <summary>
        /// This returns views requested via ajax
        /// and can also return views as whole page
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get(string viewName)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/" + viewName + ".cshtml");
            }
            return View("~/" + viewName + ".cshtml");
        }
    }
}