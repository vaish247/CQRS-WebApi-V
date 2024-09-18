using MediatR;
using Ezzy.Website.Core.Application.Queries;
using Ezzy.Website.Infrastructure.Domain.Entities;
using Ezzy.Website.Infrastructure.Domain.Interfaces;

namespace Ezzy.Website.Core.Application.Handlers
{
    public class GetAllContactItemHandler : IRequestHandler<GetAllContactItemQuery, IEnumerable<ContactItem>>
    {
        private readonly IContactItemRepository _repository;
        
        public GetAllContactItemHandler(IContactItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ContactItem>> Handle(GetAllContactItemQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllContactItemsAsync();
        }
    }
}
