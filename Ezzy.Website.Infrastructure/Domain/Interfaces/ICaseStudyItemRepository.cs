using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ezzy.Website.Infrastructure.Domain.Entities;

namespace Ezzy.Website.Infrastructure.Domain.Interfaces
{
    public interface ICaseStudyItemRepository
    {
        Task<CaseStudyItem> GetCaseStudyItemAsync(string pk, string sk);
        Task<IReadOnlyCollection<CaseStudyItem>> GetAllCaseStudyItemsAsync();
        Task AddCaseStudyItemAsync(CaseStudyItem caseStudyItem);
        Task<bool> DeleteCaseStudyItemAsync(string pk, string sk);
    }
}
