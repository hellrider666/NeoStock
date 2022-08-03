using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ClientEntities> ClientEntities { get; }
        IRepository<ClientIdentity> ClientIdentity { get; }
        IRepository<CompanyEntities> CompanyEntities { get; }
        IRepository<DepartmentEntities> DepartmentEntities { get; }
        IRepository<EmployeeEntities> EmployeeEntities { get; }
        IRepository<EnterpriseEntities> EnterpriseEntities { get; }
        IRepository<ProductionEntities> ProductionEntities { get; }
        IRepository<Roles> Roles { get; }
        void Save();
        void SaveAsync();

    }
}
