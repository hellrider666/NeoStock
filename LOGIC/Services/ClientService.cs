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
    public class ClientService : IClientService
    {
        IUnitOfWork database { get; set; }
        public ClientService(IUnitOfWork uow)
        {
            database = uow;
        }
        public IEnumerable<ClientEntitiesDTO> GetAllClients()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientEntities, ClientEntitiesDTO>().ForMember(x=>x.ClientIdentity, y=>y.MapFrom(y=>y.ClientIden))).CreateMapper();
            return mapper.Map<IEnumerable<ClientEntities>, List<ClientEntitiesDTO>>(database.ClientEntities.GetAll());
        }
    }

}
