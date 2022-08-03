using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositoryes
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DatabaseContext context;
        private ClientEntitiesRepository clientEntitiesRepository;
        private ClientIdentityRepository ClientIdentityRepository;
        private CompanyEntitiesRepository CompanyEntitiesRepository;
        private DepartmentEntitiesRepository DepartmentEntitiesRepository;
        private EmployeeEntitiesRepository EmployeeEntitiesRepository;
        private EnterpriseEntitiesRepository EnterpriseEntitiesRepository;
        private ProductionEntitiesRepository ProductionEntitiesRepository;
        private RolesRepository RolesRepository;

        public EFUnitOfWork(DatabaseContext context)
        {
            this.context = context;
        }
        public IRepository<ClientEntities> ClientEntities
        {
            get
            {
                if(clientEntitiesRepository == null)
                {
                    clientEntitiesRepository = new ClientEntitiesRepository(context);
                }
                return clientEntitiesRepository;
            }
        }
        public IRepository<ClientIdentity> ClientIdentity
        {
            get
            {
                if (ClientIdentityRepository == null)
                {
                    ClientIdentityRepository = new ClientIdentityRepository(context);
                }
                return ClientIdentityRepository;
            }
        }
        public IRepository<CompanyEntities> CompanyEntities
        {
            get
            {
                if (CompanyEntitiesRepository == null)
                {
                    CompanyEntitiesRepository = new CompanyEntitiesRepository(context);
                }
                return CompanyEntitiesRepository;
            }
        }
        public IRepository<DepartmentEntities> DepartmentEntities
        {
            get
            {
                if (DepartmentEntitiesRepository == null)
                {
                    DepartmentEntitiesRepository = new DepartmentEntitiesRepository(context);
                }
                return DepartmentEntitiesRepository;
            }
        }
        public IRepository<EmployeeEntities> EmployeeEntities
        {
            get
            {
                if (EmployeeEntitiesRepository == null)
                {
                    EmployeeEntitiesRepository = new EmployeeEntitiesRepository(context);
                }
                return EmployeeEntitiesRepository;
            }
        }
        public IRepository<EnterpriseEntities> EnterpriseEntities
        {
            get
            {
                if (EnterpriseEntitiesRepository == null)
                {
                    EnterpriseEntitiesRepository = new EnterpriseEntitiesRepository(context);
                }
                return EnterpriseEntitiesRepository;
            }
        }
        public IRepository<ProductionEntities> ProductionEntities
        {
            get
            {
                if (ProductionEntitiesRepository == null)
                {
                    ProductionEntitiesRepository = new ProductionEntitiesRepository(context);
                }
                return ProductionEntitiesRepository;
            }
        }
        public IRepository<Roles> Roles
        {
            get
            {
                if (RolesRepository == null)
                {
                    RolesRepository = new RolesRepository(context);
                }
                return RolesRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void SaveAsync()
        {
            context.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
