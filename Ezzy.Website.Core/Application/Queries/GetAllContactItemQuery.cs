using MediatR;
using Ezzy.Website.Infrastructure.Domain.Entities;

namespace Ezzy.Website.Core.Application.Queries
{
    public class GetAllContactItemQuery: IRequest<IEnumerable<ContactItem>>
    {
    }
}
