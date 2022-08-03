using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositoryes
{
    public class ProductionEntitiesRepository : IRepository<ProductionEntities>
    {
        private DatabaseContext context;
        public ProductionEntitiesRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public void Create(ProductionEntities ProductionEntities)
        {
            context.ProductionEntities.Add(ProductionEntities);
        }

        public void Delete(int Id)
        {
            ProductionEntities ProductionEntities = context.ProductionEntities.Find(Id);
            if (ProductionEntities != null)
            {
                context.ProductionEntities.Remove(ProductionEntities);
            }
        }

        public IEnumerable<ProductionEntities> GetAll()
        {
            return context.ProductionEntities;
        }

        public ProductionEntities GetByID(int Id)
        {
            return context.ProductionEntities.Find(Id);
        }

        public ProductionEntities GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductionEntities ProductionEntities)
        {
            context.Entry(ProductionEntities).State = EntityState.Modified;
        }
       
    }
}
