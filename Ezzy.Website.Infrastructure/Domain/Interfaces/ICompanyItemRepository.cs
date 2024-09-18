using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ezzy.Website.Infrastructure.Domain.Entities;

namespace Ezzy.Website.Infrastructure.Domain.Interfaces
{
    public interface ICompanyItemRepository
    {
        Task<CompanyItem> GetCompanyItemAsync(string pk,string sk);
        Task<IReadOnlyCollection<CompanyItem>> GetAllCompanyItemsAsync();
        Task AddCompanyItemAsync(CompanyItem companyItem);
        Task<bool> DeleteCompanyItemAsync(string pk, string sk);
    }
}
