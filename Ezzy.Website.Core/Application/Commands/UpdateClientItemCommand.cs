using MediatR;
using Ezzy.Website.Infrastructure.Domain.DTO;

namespace Ezzy.Website.Core.Application.Commands
{
    public class UpdateClientItemCommand : IRequest<ClientItemDTO>
    {
        public string pk { get; set; }
        public string sk { get; set; }
        public string client_logo { get; set; }
        public string client_name { get; set; }

    }
}
