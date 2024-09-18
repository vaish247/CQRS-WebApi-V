using MediatR;
using Ezzy.Website.Infrastructure.Domain.Entities;

namespace Ezzy.Website.Core.Application.Queries
{
    public class GetClientItemQuery :IRequest<ClientItem>
    {
        public string pk { get; set; }
        public string sk { get; set; }

    }
}
