using CompanyMVC.Entities;
using CompanyMVC.viewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyMVC.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        companyDb ConDb = new companyDb();
        // GET: Projects
        public ActionResult Index()
        {
            var projects = ConDb.projects.ToList();
            return View(projects);
        }

        public ActionResult View(int id, employee employee,department department)
        {
            project projectInDb = ConDb.projects.SingleOrDefault(p=>p.id == id);
            

            ProjectsViewModel viewModel = new ProjectsViewModel();
            viewModel.Project = projectInDb;
            viewModel.Employees = ConDb.employees.Where(x => x.department_id == projectInDb.department_id).ToList();

            return View(viewModel);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            
            var departments = ConDb.departments.ToList();
           

            var viewModel = new ProjectsViewModel
            {
                Project = new project(),
               
                Departments = departments
               
               

            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectsViewModel projects, HttpPostedFileBase imageFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (imageFile != null && imageFile.ContentLength > 0)
                    {
                        
                        var fileName = Path.GetFileName(imageFile.FileName);

                        var path = Path.Combine(Server.MapPath("/Content/uploads"), fileName);

                        imageFile.SaveAs(path);

                        projects.Project.imagefile = $"/Content/uploads/{fileName}";


                    }
                    else
                    {
                        projects.Departments = ConDb.departments.ToList();
                        return View("Create", projects);
                    }

                    ConDb.projects.Add(projects.Project);
                    ConDb.SaveChanges();

                    return RedirectToAction("Index");

                }

                else
                {
                    return View("Create", projects);
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }



        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var projectInDb = ConDb.projects.SingleOrDefault(p => p.id == id);
            var departments = ConDb.departments.ToList();
            ProjectsViewModel projectsView = new ProjectsViewModel
            {
                Project = projectInDb,
                Departments = departments
            };
            

            

            return View(projectsView);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectsViewModel projects)
        {
            var projectInDb = ConDb.projects.SingleOrDefault(p => p.id == id);

            if (projects.Project.id != 0)
            {
                projectInDb.name = projects.Project.name;
                projectInDb.company = projects.Project.company;
                projectInDb.requirements = projects.Project.requirements;
                projectInDb.budget = projects.Project.budget;
                projectInDb.department_id = projects.Project.department_id;
                projectInDb.start_date = projects.Project.start_date;
                projectInDb.end_date = projects.Project.end_date;
            }

            ConDb.SaveChanges();
            return RedirectToAction("Index", "Projects");
        }

        public ActionResult Delete(int id)
        {
            var projectInDb = ConDb.projects.Find(id);

            ConDb.projects.Remove(projectInDb);
            ConDb.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}