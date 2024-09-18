using AutoMapper;
using Ezzy.Website.Core.Application.Commands;
using Ezzy.Website.Infrastructure.Domain.DTO;
using Ezzy.Website.Infrastructure.Domain.Entities;

namespace Ezzy.Website.Core.Application.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<ContactItem, ContactItemDTO>().ReverseMap();
            CreateMap<AddContactItemCommand, ContactItem>().ReverseMap();
            CreateMap<ClientItem, ClientItemDTO>().ReverseMap();
            CreateMap<AddClientItemCommand, ClientItem>().ReverseMap();
        }
    }
}
