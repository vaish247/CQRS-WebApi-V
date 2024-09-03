using MediatR;
using Ezzy.Website.Infrastructure.Domain.Entities;

namespace Ezzy.Website.Core.Application.Queries
{
    public class GetContactItemQuery :IRequest<ContactItem>
    {
        public string Id { get; set; }
    }
}
