using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CQRS_WebApi_V1.Application.Queries;
using CQRS_WebApi_V1.Domain.Entities;
using CQRS_WebApi_V1.Domain.Interfaces;

namespace CQRS_WebApi_V1.Application.Handlers
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
