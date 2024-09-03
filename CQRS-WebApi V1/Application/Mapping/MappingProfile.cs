using AutoMapper;
using CQRS_WebApi_V1.Application.Commands;
using CQRS_WebApi_V1.Domain.DTO;
using CQRS_WebApi_V1.Domain.Entities;

namespace CQRS_WebApi_V1.Application.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<ContactItem, ContactItemDTO>().ReverseMap();
            CreateMap<AddContactItemCommand, ContactItem>().ReverseMap();
        
        }
    }
}
