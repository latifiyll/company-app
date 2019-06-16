using CompanyMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyMVC.viewModels
{
    public class ProjectsViewModel
    {

        public project Project { get; set; }

        public IEnumerable<department> Departments { get; set; }

        public IEnumerable<employee> Employees { get; set; }
        public department Dept { get; set; }
    }
}