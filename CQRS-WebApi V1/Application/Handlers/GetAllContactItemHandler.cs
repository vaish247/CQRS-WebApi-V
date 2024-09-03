using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CQRS_WebApi_V1.Application.Queries;
using CQRS_WebApi_V1.Domain.Entities;
using CQRS_WebApi_V1.Domain.Interfaces;

namespace CQRS_WebApi_V1.Application.Handlers
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
