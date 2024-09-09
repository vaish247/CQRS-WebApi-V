﻿using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Ezzy.Website.Infrastructure.Domain.Entities;
using Ezzy.Website.Infrastructure.Domain.Interfaces;

namespace Ezzy.Website.Infrastructure.Repository.Repositories
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
                    {"Message", new AttributeValue{ S= contactItem.Message} }
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
                    Message = item["Message"].S
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
