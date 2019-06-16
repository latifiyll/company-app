using CompanyMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        companyDb ConDb = new companyDb();
        public ActionResult Index()
        {
            var projects = ConDb.projects.ToList();
            return View(projects);
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
    }
}