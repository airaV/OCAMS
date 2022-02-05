using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCAMS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
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

        // GET: Test  
        public ActionResult Identity()
        {
            return Content("We are using Identity");
        }
        /// <summary>  
        /// Disable identity to particuler action result  
        /// </summary>  
        /// <returns></returns>  
        [AllowAnonymous]
        public ActionResult NonIdentiy()
        {
            return Content("We are not using Identity");
        }
    }
}