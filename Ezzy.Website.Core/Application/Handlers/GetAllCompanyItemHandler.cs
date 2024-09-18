using MediatR;
using Ezzy.Website.Core.Application.Queries;
using Ezzy.Website.Infrastructure.Domain.Entities;
using Ezzy.Website.Infrastructure.Domain.Interfaces;

namespace Ezzy.Website.Core.Application.Handlers
{
    public class GetAllCompanyItemHandler : IRequestHandler<GetAllCompanyItemQuery, IEnumerable<CompanyItem>>
    {
        private readonly ICompanyItemRepository _repository;
        
        public GetAllCompanyItemHandler(ICompanyItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<CompanyItem>> Handle(GetAllCompanyItemQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllCompanyItemsAsync();
        }
    }
}
