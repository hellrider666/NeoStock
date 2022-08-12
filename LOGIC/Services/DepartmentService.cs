using System;
using System.Collections.Generic;
using System.Text;
using LOGIC.DTO;
using LOGIC.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using AutoMapper;
using System.Linq;

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

        public IEnumerable<DepartmentsListDTO> GetAllDepartmentsByCompanyID(int CompId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentEntities, DepartmentsListDTO>().ForMember(x=>x.TypeName, y=>y.MapFrom(z=>z.DepartType.TypeName))).CreateMapper();
            return mapper.Map<IEnumerable<DepartmentEntities>, List<DepartmentsListDTO>>(database.DepartmentEntities.GetAll().Where(x=>x.Company.ID == CompId));
        }

        public bool CreateDepartment(CreateDepartmentDTO departmentDTO, int DepartTypeId, int CompanyId)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CreateDepartmentDTO, DepartmentEntities>()).CreateMapper();
                var department = mapper.Map<CreateDepartmentDTO, DepartmentEntities>(departmentDTO);
                department.DepartType = database.DepartTypesEntities.GetByID(DepartTypeId);
                department.Company = database.CompanyEntities.GetByString(Convert.ToString(CompanyId));
                database.DepartmentEntities.Create(department);
                database.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
