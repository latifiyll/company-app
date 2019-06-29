using CompanyMVC.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyMVC.viewModels;
using System.Data.Entity.Validation;
using AutoMapper;

namespace CompanyMVC.Controllers
{
    [Authorize]
    public class EmployesController : Controller
    {
        private companyDb ConDb = new companyDb();


        // GET: Employes
        public ActionResult Index()
        {
            var employees = ConDb.employees.ToList();
            return View(employees);
        }

        public ActionResult View(int id)
        {
            var getEmployee = ConDb.employees.SingleOrDefault(empId => empId.id == id);

            return View(getEmployee);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var positions = ConDb.positions.ToList();
            var departments = ConDb.departments.ToList();
            var workType = ConDb.work_type.ToList();
            var schedule = ConDb.schedules.ToList();

            var viewModel = new EmployeeViewModel
            {
                Employees = new employee(),
                Position = positions,
                Department = departments,
                WorkType = workType,
                Schedule = schedule

            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ConDb.employees.Add(employee.Employees);
                    ConDb.SaveChanges();

                    return RedirectToAction("Index");
                }

                else
                {
                    return View("Create", employee);
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
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {

            var employeeInDb = ConDb.employees.SingleOrDefault(e => e.id == id);
            var positionInDb = ConDb.positions.ToList();
            var departmentsInDb = ConDb.departments.ToList();
            var worktypeInDb = ConDb.work_type.ToList();
            var scheduleInDb = ConDb.schedules.ToList();

            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.Employees = employeeInDb;
            employeeViewModel.Position = positionInDb;
            employeeViewModel.Department = departmentsInDb;
            employeeViewModel.WorkType = worktypeInDb;
            employeeViewModel.Schedule = scheduleInDb;

            return View(employeeViewModel);
        }
        [HttpPost]
        public ActionResult Edit(int id, EmployeeViewModel employee)
        {
            var employeesInDb = ConDb.employees.SingleOrDefault(e => e.id == id);
            if (employee.Employees.id != 0)
            {


                employeesInDb.name = employee.Employees.name;
                employeesInDb.surname = employee.Employees.surname;
                employeesInDb.personal_nr = employee.Employees.personal_nr;
                employeesInDb.identity_card_nr = employee.Employees.identity_card_nr;
                employeesInDb.position_id = employee.Employees.position_id;
                employeesInDb.department_id = employee.Employees.department_id;
                employeesInDb.work_type_id = employee.Employees.work_type_id;
                employeesInDb.schedule_id = employee.Employees.schedule_id;
                employeesInDb.salary = employee.Employees.salary;
                employeesInDb.email = employee.Employees.email;
                employeesInDb.start_date = employee.Employees.start_date;
                employeesInDb.end_date = employee.Employees.end_date;
            }


            ConDb.SaveChanges();

            return RedirectToAction("Index", "Employes");
        }


        public ActionResult Delete(int id)
        {
            employee employeeInDb = ConDb.employees.Find(id);

            ConDb.employees.Remove(employeeInDb);

            ConDb.SaveChanges();

            return RedirectToAction("Index", "Employes");
        }

    }

}