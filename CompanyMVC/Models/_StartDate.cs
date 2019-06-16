using CompanyMVC.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyMVC.Models
{
    public class StartDate : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var startDate = (employee_vacation)validationContext.ObjectInstance;


            DateTime dateTime = Convert.ToDateTime(startDate.start_date);


            if (dateTime > DateTime.Today)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date should be greater than today's date");
            }




        }
    }
    public class VacationDays : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var vacationDays = (employee_vacation)validationContext.ObjectInstance;

            int vacDays = Convert.ToInt32(vacationDays.vac_days);

            if (vacDays < 0)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }

}