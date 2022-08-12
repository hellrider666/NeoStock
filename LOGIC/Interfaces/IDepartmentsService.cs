using System;
using System.Collections.Generic;
using System.Text;
using LOGIC.DTO;

namespace LOGIC.Interfaces
{
    public interface IDepartmentsService
    {
        IEnumerable<DepartTypesDTO> GetAllDepartsTypes();
        IEnumerable<DepartmentsListDTO> GetAllDepartmentsByCompanyID(int CompId);
        bool CreateDepartment(CreateDepartmentDTO departmentDTO, int DepartTypeId, int CompanyId);
    }
}
