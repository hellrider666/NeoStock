using AutoMapper;
using DAL.Entities;
using DAL.Interfaces;
using LOGIC.DTO;
using LOGIC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LOGIC.Services
{
    public class CompaniesService : ICompaniesService
    {
        IUnitOfWork database { get; set; }
        public CompaniesService(IUnitOfWork uow)
        {
            database = uow;
        }
        public IEnumerable<CompaniesDTO> GetAllCompaniesByClientLogin(string Login)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CompanyEntities, CompaniesDTO>().ForMember(x => x.EnterpriseName, y => y.MapFrom(y => y.EnterpriseType.EnterpriseName))).CreateMapper();
            return mapper.Map<IEnumerable<CompanyEntities>, List<CompaniesDTO>>(database.CompanyEntities.GetAll().Where(x => x.Client.ClientIden.Login == Login));
        }

        public IEnumerable<CompaniesTypesListDTO> GetAllCompaniesTypes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EnterpriseEntities, CompaniesTypesListDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<EnterpriseEntities>, List<CompaniesTypesListDTO>>(database.EnterpriseEntities.GetAll());
        }

        public bool CreateCompany(CreateCompanyDTO company_, int Id, string Login)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CreateCompanyDTO, CompanyEntities>()).CreateMapper();
                var company = mapper.Map<CreateCompanyDTO, CompanyEntities>(company_);
                company.EnterpriseType = database.EnterpriseEntities.GetByID(Id);
                company.Client = database.ClientEntities.GetByString(Login);
                database.CompanyEntities.Create(company);
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
