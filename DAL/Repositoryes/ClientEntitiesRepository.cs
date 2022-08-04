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
    public class ClientEntitiesRepository : IRepository<ClientEntities>
    {
        private DatabaseContext context;
        public ClientEntitiesRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public void Create(ClientEntities ClientEntity)
        {
            context.clientEntities.Add(ClientEntity);
        }

        public void Delete(int Id)
        {
            ClientEntities clientEntities = context.clientEntities.Find(Id);
            if(clientEntities != null)
            {
                context.clientEntities.Remove(clientEntities);
            }
        }

        public IEnumerable<ClientEntities> GetAll()
        {
            return context.clientEntities.Include(x=>x.ClientIden);
        }

        public ClientEntities GetByID(int Id)
        {
            return context.clientEntities.Find(Id);
        }

        public ClientEntities GetByString(string value)
        {
            return context.clientEntities.Include(x => x.ClientIden).FirstOrDefault(y => y.ClientIden.Login == value);
        }

        public void Update(ClientEntities clientEntities)
        {
            context.Entry(clientEntities).State = EntityState.Modified;
        }
        
    }
}
