using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using CQRS_WebApi_V1.Domain.Entities;
using CQRS_WebApi_V1.Domain.Interfaces;

namespace CQRS_WebApi_V1.Repository.Repositories
{
    public class ContactItemRepository : IContactItemRepository
    {
        private const string TableName = "ContactItems";
        private readonly IAmazonDynamoDB _dynamoDbClient;

        public ContactItemRepository(IAmazonDynamoDB dynamoDBClient)
        {
            _dynamoDbClient = dynamoDBClient;
        }
        public async Task AddContactItemAsync(ContactItem contactItem)
        {
            if (contactItem == null)
            {
                throw new ArgumentNullException(nameof(contactItem));
            }
            var request = new PutItemRequest
            {
                TableName = TableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    {"Id", new AttributeValue{ S= contactItem.Id} },
                    {"Name", new AttributeValue{ S= contactItem.Name} },
                    {"Email", new AttributeValue{ S= contactItem.Email} },
                    {"Company", new AttributeValue{ S= contactItem.Company} },
                    {"Phone", new AttributeValue{ S= contactItem.Phone} },
                    {"Message", new AttributeValue{ S= contactItem.Message} },
                    {"Budget", new AttributeValue{ S= contactItem.Budget} }
                }
            };
            await _dynamoDbClient.PutItemAsync(request);
        }
        public async Task<ContactItem> GetContactItemAsync(string Id)
        {
            var request = new GetItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    {"Id",new AttributeValue { S= Id} }
                }
            };

            var response = await _dynamoDbClient.GetItemAsync(request);
            if (response.Item == null || response.Item.Count == 0)
            {
                return null;
            }

            return new ContactItem
            {
                Id = response.Item["Id"].S,
                Name = response.Item["Name"].S,
                Email = response.Item["Email"].S,
                Company = response.Item["Company"].S,
                Phone = response.Item["Phone"].S,
                Message = response.Item["Message"].S,
                Budget = response.Item["Budget"].S
            };

        }
    
        public async Task<IReadOnlyCollection<ContactItem>> GetAllContactItemsAsync()
        {
            var request = new ScanRequest
            {
                TableName = TableName
            };

            var response = await _dynamoDbClient.ScanAsync(request);
            var contactItemList = new List<ContactItem>();
            foreach (var item in response.Items)
            {
                contactItemList.Add(new ContactItem
                {
                    Id = (item["Id"].S),
                    Name = item["Name"].S,
                    Email = item["Email"].S,
                    Company = item["Company"].S,
                    Phone = item["Phone"].S,
                    Message = item["Message"].S,
                    Budget = item["Budget"].S
                });
            }
            return contactItemList;

        }


        public async Task<bool> DeleteContactItemAsync(string? Id)
        {
            var request = new DeleteItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "Id", new AttributeValue { S = Id } }
                }
            };

            var response = await _dynamoDbClient.DeleteItemAsync(request);
            return response.HttpStatusCode == System.Net.HttpStatusCode.OK;

         }

    }

}
