using MediatR;
using Ezzy.Website.Core.Application.Queries;
using Ezzy.Website.Infrastructure.Domain.Entities;
using Ezzy.Website.Infrastructure.Domain.Interfaces;

namespace Ezzy.Website.Core.Application.Handlers
{
    public class GetCaseStudyItemHandler : IRequestHandler<GetCaseStudyItemQuery, CaseStudyItem>
    {
        private readonly ICaseStudyItemRepository _repository;

        public GetCaseStudyItemHandler(ICaseStudyItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<CaseStudyItem> Handle(GetCaseStudyItemQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCaseStudyItemAsync(request.pk, request.sk);
        }
    }
}
