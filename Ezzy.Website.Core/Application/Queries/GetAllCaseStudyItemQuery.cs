using MediatR;
using Ezzy.Website.Infrastructure.Domain.Entities;

namespace Ezzy.Website.Core.Application.Queries
{
    public class GetAllCaseStudyItemQuery: IRequest<IEnumerable<CaseStudyItem>>
    {
    }
}
