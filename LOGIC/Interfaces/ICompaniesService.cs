using LOGIC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC.Interfaces
{
    public interface ICompaniesService
    {
        IEnumerable<CompaniesDTO> GetAllCompaniesByClientLogin(string Login);
        IEnumerable<CompaniesTypesListDTO> GetAllCompaniesTypes();
        bool CreateCompany(CreateCompanyDTO company_, int Id, string Login);
    }
}
