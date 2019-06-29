using AutoMapper;
using CompanyMVC.Entities;
using CompanyMVC.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyMVC.App_Start
{
    public class MappingConfig  
    {
        private readonly IMapper _mapper;
        public MappingConfig()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeViewModel, employee>();
            });
            
            _mapper = new Mapper(config);
            var dest = _mapper.Map<EmployeeViewModel, employee>(new EmployeeViewModel());

        }

        public void Configure()
        {
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<EmployeeViewModel, employee>();
            //    cfg.CreateMap< employee, EmployeeViewModel>();
            //});
        }
    }
}