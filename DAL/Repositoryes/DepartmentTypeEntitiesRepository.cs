using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositoryes
{
    class DepartmentTypeEntitiesRepository :IRepository<DepartmentTypesEntities>
    {
        private DatabaseContext context;
        public DepartmentTypeEntitiesRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public void Create(DepartmentTypesEntities DepartmentTypesEntities)
        {
            context.DepartmentTypesEntities.Add(DepartmentTypesEntities);
        }

        public void Delete(int Id)
        {
            DepartmentTypesEntities DepartmentTypesEntities = context.DepartmentTypesEntities.Find(Id);
            if (DepartmentTypesEntities != null)
            {
                context.DepartmentTypesEntities.Remove(DepartmentTypesEntities);
            }
        }

        public IEnumerable<DepartmentTypesEntities> GetAll()
        {
            return context.DepartmentTypesEntities;
        }

        public DepartmentTypesEntities GetByID(int Id)
        {
            return context.DepartmentTypesEntities.Find(Id);
        }

        public DepartmentTypesEntities GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(DepartmentTypesEntities DepartmentTypesEntities)
        {
            context.Entry(DepartmentTypesEntities).State = EntityState.Modified;
        }
    }
}
