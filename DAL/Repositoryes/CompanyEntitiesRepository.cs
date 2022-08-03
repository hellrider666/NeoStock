﻿using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositoryes
{
    public class CompanyEntitiesRepository : IRepository<CompanyEntities>
    {
        private DatabaseContext context;
        public CompanyEntitiesRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public void Create(CompanyEntities CompanyEntities)
        {
            context.CompanyEntities.Add(CompanyEntities);
        }

        public void Delete(int Id)
        {
            CompanyEntities CompanyEntities = context.CompanyEntities.Find(Id);
            if (CompanyEntities != null)
            {
                context.CompanyEntities.Remove(CompanyEntities);
            }
        }

        public IEnumerable<CompanyEntities> GetAll()
        {
            return context.CompanyEntities;
        }

        public CompanyEntities GetByID(int Id)
        {
            return context.CompanyEntities.Find(Id);
        }

        public CompanyEntities GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(CompanyEntities CompanyEntities)
        {
            context.Entry(CompanyEntities).State = EntityState.Modified;
        }
        
    }
}
