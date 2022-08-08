using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionalBuild
        {
            public OptionalBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                opsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;
            }
            public DbContextOptionsBuilder<DatabaseContext> opsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> dbOptions { get; set; }
            private AppConfiguration settings { get; set; }
        }

        public static OptionalBuild ops = new OptionalBuild();
        public DatabaseContext(DbContextOptions<DatabaseContext> options) :base(options) { }
        public DbSet<DepartmentTypesEntities> DepartmentTypesEntities { get; set; }
        public DbSet<ClientIdentity> clientIdentities { get; set; }
        public DbSet<ClientEntities> clientEntities { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<CompanyEntities> CompanyEntities { get; set; }
        public DbSet<EmployeeEntities> EmployeeEntities { get; set; }
        public DbSet<ProductionEntities> ProductionEntities { get; set; }
        public DbSet<EnterpriseEntities> EnterpriseEntities { get; set; }
        public DbSet<DepartmentEntities> DepartmentEntities { get; set; }

    }
}
