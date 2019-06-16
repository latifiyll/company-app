using CompanyMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyMVC.viewModels
{
    public class VacationViewModel
    {
        public employee_vacation Empl_vac { get; set; }

        public IEnumerable<employee> Employees { get; set; }

        public IEnumerable<vacation> Vacations { get; set; }
    }
}