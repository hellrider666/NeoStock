using AutoMapper;
using DAL.Entities;
using DAL.Interfaces;
using LOGIC.DTO;
using LOGIC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC.Services
{
    public class RegistrationService : IRegistrationService
    {
        IUnitOfWork database { get; set; }
        public RegistrationService(IUnitOfWork uow)
        {
            database = uow;
        }     
        public bool CreateUser(RegistrationDTO user)
        {
            if (database.ClientIdentity.GetByString(user.Login) == null)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RegistrationDTO, ClientIdentity>()).CreateMapper();
                var _user = mapper.Map<RegistrationDTO, ClientIdentity>(user);
                ClientEntities clientEntity = new ClientEntities();
                clientEntity.ClientIden = _user;
                _user.ClientEntity = clientEntity;
                _user.Role = database.Roles.GetByString("Предприниматель");
                database.ClientEntities.Create(clientEntity);
                database.ClientIdentity.Create(_user);
                database.Save();
                return true;
            }
            return false;
        }

        
    }
}
