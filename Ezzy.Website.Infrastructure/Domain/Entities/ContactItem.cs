using System;
namespace Ezzy.Website.Infrastructure.Domain.Entities
{
    public class ContactItem
    {
        public string Id { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Message { get; set; }
        public string Budget { get; set; }
    }
}
