using MediatR;
using Ezzy.Website.Core.Application.Queries;
using Ezzy.Website.Infrastructure.Domain.Entities;
using Ezzy.Website.Infrastructure.Domain.Interfaces;

namespace Ezzy.Website.Core.Application.Handlers
{
    public class GetClientItemHandler : IRequestHandler<GetClientItemQuery, ClientItem>
    {
        private readonly IClientItemRepository _repository;

        public GetClientItemHandler(IClientItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<ClientItem> Handle(GetClientItemQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetClientItemAsync(request.pk, request.sk);
        }
    }
}
