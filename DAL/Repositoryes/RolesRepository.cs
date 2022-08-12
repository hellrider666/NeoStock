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
    public class RolesRepository : IRepository<Roles>
    {
        private DatabaseContext context;
        public RolesRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public void Create(Roles Roles)
        {
            context.Roles.Add(Roles);
        }
        public void Delete(int Id)
        {
            Roles Roles = context.Roles.Find(Id);
            if (Roles != null)
            {
                context.Roles.Remove(Roles);
            }
        }
        public IEnumerable<Roles> GetAll()
        {
            return context.Roles;
        }

        public Roles GetByAuthData(string val_1, string val_2)
        {
            throw new NotImplementedException();
        }

        public Roles GetByID(int Id)
        {
            return context.Roles.Find(Id);
        }

        public Roles GetByString(string value)
        {
            return context.Roles.FirstOrDefault(x => x.RoleName == value);
        }

        public void Update(Roles Roles)
        {
            context.Entry(Roles).State = EntityState.Modified;
        }
        
    }
}
