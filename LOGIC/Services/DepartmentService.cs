using System;
using System.Collections.Generic;
using System.Text;
using LOGIC.DTO;
using LOGIC.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using AutoMapper;

namespace LOGIC.Services
{

    public class DepartmentService : IDepartmentsService
    {
        IUnitOfWork database { get; set; }
        public DepartmentService(IUnitOfWork uow)
        {
            database = uow;
        }

        public IEnumerable<DepartTypesDTO> GetAllDepartsTypes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentTypesEntities, DepartTypesDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<DepartmentTypesEntities>, List<DepartTypesDTO>>(database.DepartTypesEntities.GetAll());
        }

        public IEnumerable<DepartmentsListDTO> GetAllDepartmentsByCompanyID()
        {
            throw new NotImplementedException();
        }

        public bool CreateDepartment(CreateDepartmentDTO departmentDTO, int DepartTypeId, int CompanyId)
        {
            throw new NotImplementedException();
        }
    }
}
