using System;
using MediatR;
using Ezzy.Website.Infrastructure.Domain.DTO;

namespace Ezzy.Website.Core.Application.Commands
{
    public class AddContactItemCommand : IRequest<ContactItemDTO>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Message { get; set; }
    }
}
