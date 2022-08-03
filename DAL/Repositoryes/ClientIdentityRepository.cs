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
    public class ClientIdentityRepository : IRepository<ClientIdentity>
    {
        private DatabaseContext context;
        public ClientIdentityRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public void Create(ClientIdentity ClientIdentity)
        {
            context.clientIdentities.Add(ClientIdentity);
        }

        public void Delete(int Id)
        {
            ClientIdentity clientIdentity = context.clientIdentities.Find(Id);
            if (clientIdentity != null)
            {
                context.clientIdentities.Remove(clientIdentity);
            }
        }

        public IEnumerable<ClientIdentity> GetAll()
        {
            return context.clientIdentities;
        }

        public ClientIdentity GetByID(int Id)
        {
            return context.clientIdentities.FirstOrDefault(x=>x.ID == Id);
        }
        public ClientIdentity GetByString(string login)
        {
            return context.clientIdentities.Include(y=>y.Role).FirstOrDefault(x=>x.Login == login);
        }
        

        public void Update(ClientIdentity ClientIdentity)
        {
            context.Entry(ClientIdentity).State = EntityState.Modified;
        }
        
    }
}
