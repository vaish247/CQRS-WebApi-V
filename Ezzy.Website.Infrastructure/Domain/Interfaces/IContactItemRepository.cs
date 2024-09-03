using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ezzy.Website.Infrastructure.Domain.Entities;

namespace Ezzy.Website.Infrastructure.Domain.Interfaces
{
    public interface IContactItemRepository
    {
        //Retrieves a single ContactItem based on its identifier.
        Task<ContactItem> GetContactItemAsync(string Id);
        //Retrieves all ContactItem entities.
        Task<IReadOnlyCollection<ContactItem>> GetAllContactItemsAsync();
        //Adds a new ContactItem to the repository
        Task AddContactItemAsync(ContactItem contactItem);
        //Deletes a ContactItem based on its unique identifier. Returns true if the deletion was successful
        Task<bool> DeleteContactItemAsync(string? Id);
    }
}
