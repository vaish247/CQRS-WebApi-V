using MediatR;
using Ezzy.Website.Core.Application.Queries;
using Ezzy.Website.Infrastructure.Domain.Entities;
using Ezzy.Website.Infrastructure.Domain.Interfaces;

namespace Ezzy.Website.Core.Application.Handlers
{
    public class GetCompanyItemHandler : IRequestHandler<GetCompanyItemQuery, CompanyItem>
    {
        private readonly ICompanyItemRepository _repository;

        public GetCompanyItemHandler(ICompanyItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<CompanyItem> Handle(GetCompanyItemQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCompanyItemAsync(request.pk, request.sk);
        }
    }
}
