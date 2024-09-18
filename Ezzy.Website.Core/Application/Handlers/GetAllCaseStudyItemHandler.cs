using MediatR;
using Ezzy.Website.Core.Application.Queries;
using Ezzy.Website.Infrastructure.Domain.Entities;
using Ezzy.Website.Infrastructure.Domain.Interfaces;

namespace Ezzy.Website.Core.Application.Handlers
{
    public class GetAllCaseStudyItemHandler : IRequestHandler<GetAllCaseStudyItemQuery, IEnumerable<CaseStudyItem>>
    {
        private readonly ICaseStudyItemRepository _repository;
        
        public GetAllCaseStudyItemHandler(ICaseStudyItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<CaseStudyItem>> Handle(GetAllCaseStudyItemQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllCaseStudyItemsAsync();
        }
    }
}
