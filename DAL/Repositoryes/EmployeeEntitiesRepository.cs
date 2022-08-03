using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositoryes
{
    public class EmployeeEntitiesRepository : IRepository<EmployeeEntities>
    {
        private DatabaseContext context;
        public EmployeeEntitiesRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public void Create(EmployeeEntities EmployeeEntities)
        {
            context.EmployeeEntities.Add(EmployeeEntities);
        }

        public void Delete(int Id)
        {
            EmployeeEntities EmployeeEntities = context.EmployeeEntities.Find(Id);
            if (EmployeeEntities != null)
            {
                context.EmployeeEntities.Remove(EmployeeEntities);
            }
        }

        public IEnumerable<EmployeeEntities> GetAll()
        {
            return context.EmployeeEntities;
        }

        public EmployeeEntities GetByID(int Id)
        {
            return context.EmployeeEntities.Find(Id);
        }

        public EmployeeEntities GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(EmployeeEntities EmployeeEntities)
        {
            context.Entry(EmployeeEntities).State = EntityState.Modified;
        }
        
    }
}
