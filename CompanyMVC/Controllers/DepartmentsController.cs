using CompanyMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyMVC.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        companyDb ConDb = new companyDb();
        // GET: Departments
        public ActionResult Index()
        {
            var departments = ConDb.departments.ToList();
            return View(departments);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(department department)
        {
            if (ModelState.IsValid)
            {
                ConDb.departments.Add(department);
                ConDb.SaveChanges();

                return RedirectToAction("Index");
            }else
            {
                return View("Create",department);
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var departments = ConDb.departments.SingleOrDefault(d => d.id == id);

            ConDb.departments.Remove(departments);
            ConDb.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}