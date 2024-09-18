using Ezzy.Website.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezzy.Website.Infrastructure.Domain.Interfaces
{
    public interface IClientItemRepository
    {
        Task<ClientItem> GetClientItemAsync(string pk, string sk);
        Task<IReadOnlyCollection<ClientItem>> GetAllClientItemsAsync();
        Task AddClientItemAsync(ClientItem clientItem);
        Task<bool> DeleteClientItemAsync(string pk, string sk);

    }
}
