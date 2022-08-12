using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositoryes
{
    public class EnterpriseEntitiesRepository : IRepository<EnterpriseEntities>
    {
        private DatabaseContext context;
        public EnterpriseEntitiesRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public void Create(EnterpriseEntities EnterpriseEntities)
        {
            context.EnterpriseEntities.Add(EnterpriseEntities);
        }

        public void Delete(int Id)
        {
            EnterpriseEntities EnterpriseEntities = context.EnterpriseEntities.Find(Id);
            if (EnterpriseEntities != null)
            {
                context.EnterpriseEntities.Remove(EnterpriseEntities);
            }
        }

        public IEnumerable<EnterpriseEntities> GetAll()
        {
            return context.EnterpriseEntities;
        }

        public EnterpriseEntities GetByAuthData(string val_1, string val_2)
        {
            throw new NotImplementedException();
        }

        public EnterpriseEntities GetByID(int Id)
        {
            return context.EnterpriseEntities.FirstOrDefault(x=>x.ID == Id);
        }

        public EnterpriseEntities GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(EnterpriseEntities EnterpriseEntities)
        {
            context.Entry(EnterpriseEntities).State = EntityState.Modified;
        }
        
    }
}
