using LOGIC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC.Interfaces
{
    public interface IClientService
    {
        IEnumerable<ClientEntitiesDTO> GetAllClients();
    }
}
