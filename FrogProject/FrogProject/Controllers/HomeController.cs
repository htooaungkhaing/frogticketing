using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrogProject.Controllers
{
    public class HomeController : Controller
    {
 
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult map()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public static string MakeActiveClass(this UrlHelper urlHelper, string controller)
        //{
        //    string result = "active";

        //    string controllerName = urlHelper.RequestContext.RouteData.Values["controller"].ToString();

        //    if (!controllerName.Equals(controller, StringComparison.OrdinalIgnoreCase))
        //    {
        //        result = null;
        //    }

        //    return result;
        //}
    }
}