using MediatR;
using Ezzy.Website.Core.Application.Queries;
using Ezzy.Website.Infrastructure.Domain.Entities;
using Ezzy.Website.Infrastructure.Domain.Interfaces;

namespace Ezzy.Website.Core.Application.Handlers
{
    public class GetContactItemHandler : IRequestHandler<GetContactItemQuery, ContactItem>
    {
        private readonly IContactItemRepository _repository;

        public GetContactItemHandler(IContactItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<ContactItem> Handle(GetContactItemQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetContactItemAsync(request.Id);
        }
    }
}
