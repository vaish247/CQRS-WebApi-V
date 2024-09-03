using System;
using MediatR;
using CQRS_WebApi_V1.Domain.DTO;

namespace CQRS_WebApi_V1.Application.Commands
{
    public class AddContactItemCommand : IRequest<ContactItemDTO>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Message { get; set; }
        public string Budget { get; set; }
    }
}
