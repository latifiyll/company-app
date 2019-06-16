using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CompanyMVC.Entities;

namespace CompanyMVC.Controllers.API
{
    public class employee_vacController : ApiController
    {
        private companyDb db = new companyDb();

        public employee_vacController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/employee_vac
        public IEnumerable<employee_vacation> Getemployee_Vacation()
        {
            return db.employee_vacation.Include(e => e.employee).ToList();
        }

        [HttpDelete]
        public void DeleteEmployeeVac(int id)
        {
            var employee_vac = db.employee_vacation.SingleOrDefault(ev => ev.id == id);

            if (employee_vac == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }else
            {
                db.employee_vacation.Remove(employee_vac);
                db.SaveChanges();
            }
            
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