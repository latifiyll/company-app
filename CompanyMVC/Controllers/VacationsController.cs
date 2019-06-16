using CompanyMVC.Entities;
using CompanyMVC.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyMVC.ExtensionMethods;

namespace CompanyMVC.Controllers
{
    [Authorize]
    public class VacationsController : Controller
    {
        companyDb ConDb = new companyDb();
        // GET: Vacations
        public ActionResult Index()
        {
            var vacationsInDb = ConDb.employee_vacation.ToList();
            vacationsInDb = ConDb.employee_vacation.Where(end => end.end_date > DateTime.Today).ToList();
            return View(vacationsInDb);
        }

        public ActionResult View(int id)
        {
            var vacationInDb = ConDb.employee_vacation.SingleOrDefault(ev => ev.id == id);

            return View(vacationInDb);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var employees = ConDb.employees.ToList();
            var vacationType = ConDb.vacations.ToList();

            VacationViewModel vacViewModel = new VacationViewModel
            {
                Empl_vac = new employee_vacation(),
                Employees = employees,
                Vacations = vacationType

            };
            return View(vacViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VacationViewModel employee_Vacation)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    var employeeVacations = ConDb.employee_vacation.Where(p => p.employee_id == employee_Vacation.Empl_vac.employee_id).ToList();

                    if(employeeVacations.Any())
                    {
                        var lastEmployeeVacation = employeeVacations.Last();

                        if (Convert.ToDateTime(lastEmployeeVacation.end_date) > Convert.ToDateTime(employee_Vacation.Empl_vac.start_date))
                        {
                            ModelState.AddModelError("Empl_vac.start_date", "You can't take vacation on this date, because you are already in vacation!!");
                            employee_Vacation.Employees = ConDb.employees.ToList();
                            employee_Vacation.Vacations = ConDb.vacations.ToList();
                            return View(employee_Vacation);
                        }

                    }
                    employee_Vacation.Empl_vac.end_date = Convert.ToDateTime(employee_Vacation.Empl_vac.start_date).AddBusinessDays(Convert.ToInt32(employee_Vacation.Empl_vac.vac_days));
                    ConDb.employee_vacation.Add(employee_Vacation.Empl_vac);
                    ConDb.SaveChanges();

                    return RedirectToAction("Index");
                    

                }               

                employee_Vacation.Employees = ConDb.employees.ToList();
                employee_Vacation.Vacations = ConDb.vacations.ToList();
                return View(employee_Vacation);
            }
            catch (Exception e)
            {

                throw;
            }
           
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var empl_vacInDb = ConDb.employee_vacation.SingleOrDefault(ev => ev.id == id);

            VacationViewModel vacViewModel = new VacationViewModel();
            vacViewModel.Empl_vac = empl_vacInDb;

            return View(vacViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VacationViewModel employee_Vacation)
        {
            var employeeVac = ConDb.employee_vacation.SingleOrDefault(ev => ev.id == id);

            if (employee_Vacation.Empl_vac.id != 0)
            {
                employeeVac.employee_id = employee_Vacation.Empl_vac.employee_id;
                employeeVac.vacation_id = employee_Vacation.Empl_vac.vacation_id;
                employeeVac.vac_days = employee_Vacation.Empl_vac.vac_days;
                employeeVac.start_date = employee_Vacation.Empl_vac.start_date;
                //employeeVac.end_date = employee_Vacation.Empl_vac.end_date;
            }
            ConDb.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var employeeVac = ConDb.employee_vacation.Find(id);

            ConDb.employee_vacation.Remove(employeeVac);

            ConDb.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}