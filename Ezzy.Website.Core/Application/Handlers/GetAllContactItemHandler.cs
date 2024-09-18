using MediatR;
using Ezzy.Website.Core.Application.Queries;
using Ezzy.Website.Infrastructure.Domain.Entities;
using Ezzy.Website.Infrastructure.Domain.Interfaces;

namespace Ezzy.Website.Core.Application.Handlers
{
    public class GetAllClientItemHandler : IRequestHandler<GetAllClientItemQuery, IEnumerable<ClientItem>>
    {
        private readonly IClientItemRepository _repository;
        
        public GetAllClientItemHandler(IClientItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ClientItem>> Handle(GetAllClientItemQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllClientItemsAsync();
        }
    }
}
