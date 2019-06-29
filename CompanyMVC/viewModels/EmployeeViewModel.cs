using CompanyMVC.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyMVC.viewModels
{
    public class EmployeeViewModel
    {
        //public EmployeeViewModel()
        //{
        //    Position = new IEnumerable<position>();
        //}
       
        public employee Employees { get; set; }

        public IEnumerable<position> Position { get; set; }

        

        public IEnumerable<department> Department { get; set; }

        public IEnumerable<work_type> WorkType { get; set; }

        public IEnumerable<schedule> Schedule { get; set; }


        
    }       
}