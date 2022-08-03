using AutoMapper;
using LOGIC.DTO;
using InventoryControlProject.Models;

namespace InventoryControlProject
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientEntitiesDTO, ClientEntitiesViewModel>().ForMember(x => x.ClientIdentity, y => y.MapFrom(y => y.ClientIdentity));
            CreateMap<AuthViewModel, AuthDTO>().ForMember(x => x.Role, y => y.MapFrom(z => z.Role));
            CreateMap<RegistrationViewModel, RegistrationDTO>();            
        }
    }
}
