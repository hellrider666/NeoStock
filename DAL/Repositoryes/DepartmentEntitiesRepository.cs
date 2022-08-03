using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositoryes
{
    public class DepartmentEntitiesRepository : IRepository<DepartmentEntities>
    {
        private DatabaseContext context;
        public DepartmentEntitiesRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public void Create(DepartmentEntities DepartmentEntities)
        {
            context.DepartmentEntities.Add(DepartmentEntities);
        }

        public void Delete(int Id)
        {
            DepartmentEntities DepartmentEntities = context.DepartmentEntities.Find(Id);
            if (DepartmentEntities != null)
            {
                context.DepartmentEntities.Remove(DepartmentEntities);
            }
        }

        public IEnumerable<DepartmentEntities> GetAll()
        {
            return context.DepartmentEntities;
        }

        public DepartmentEntities GetByID(int Id)
        {
            return context.DepartmentEntities.Find(Id);
        }

        public DepartmentEntities GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(DepartmentEntities DepartmentEntities)
        {
            context.Entry(DepartmentEntities).State = EntityState.Modified;
        }
        
    }
}
