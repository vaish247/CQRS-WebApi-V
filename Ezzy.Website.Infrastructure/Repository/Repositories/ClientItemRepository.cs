using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Ezzy.Website.Infrastructure.Domain.Entities;
using Ezzy.Website.Infrastructure.Domain.Interfaces;

namespace Ezzy.Website.Infrastructure.Repository.Repositories
{
    public class ClientItemRepository : IClientItemRepository
    {
        private const string TableName = "ezzysoft-maintable";
        private readonly IAmazonDynamoDB _dynamoDbClient;

        public ClientItemRepository(IAmazonDynamoDB dynamoDBClient)
        {
            _dynamoDbClient = dynamoDBClient;
        }
        public async Task AddClientItemAsync(ClientItem clientItem)
        {
            if (clientItem == null)
            {
                throw new ArgumentNullException(nameof(clientItem));
            }
            var request = new PutItemRequest
            {
                TableName = TableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    {"pk", new AttributeValue{ S= clientItem.pk} },
                    {"sk", new AttributeValue{ S= clientItem.sk} },
                    {"client_logo", new AttributeValue{ S= clientItem.client_logo} },
                    {"client_name", new AttributeValue{ S= clientItem.client_name} },
                }
            };
            await _dynamoDbClient.PutItemAsync(request);
        }    
        public async Task<ClientItem> GetClientItemAsync(string pk, string sk)
        {
            var request = new GetItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    {"pk",new AttributeValue { S= pk} },
                    {"sk", new AttributeValue { S =sk}}
                }
            };
            try
            {
                var response = await _dynamoDbClient.GetItemAsync(request);
                if (response.Item.Count >0)
                {
                    Console.WriteLine("Client retrieved successfully");
                    foreach(var attribute in response.Item)
                    {
                        Console.WriteLine($"{attribute.Key}: {attribute.Value.S}");
                    }

                }
                else
                {
                    Console.WriteLine("Client not found");
                }

                return new ClientItem
                {
                    pk = response.Item["pk"].S,
                    sk = response.Item["sk"].S,
                    client_logo = response.Item["client_logo"].S,
                    client_name = response.Item["client_name"].S,
                };

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Error Occured");
            return null;
        }

        public async Task<IReadOnlyCollection<ClientItem>> GetAllClientItemsAsync()
        {
            var partitionKeyValue = "COMPANY#1";
            var sortKeyPrefix = "CLIENT#";

            var request = new QueryRequest
            {
                TableName = TableName,
                KeyConditionExpression = "pk = :pk AND begins_with(sk, :sk)",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
            {
                {":pk", new AttributeValue { S = partitionKeyValue }},
                {":sk", new AttributeValue { S = sortKeyPrefix }}
            }

            };

            var response = await _dynamoDbClient.QueryAsync(request);
            var clientItemList = new List<ClientItem>();
            foreach (var item in response.Items)
            {
                clientItemList.Add(new ClientItem
                {
                    pk = (item["pk"].S),
                    sk = item["sk"].S,
                    client_logo = item["client_logo"].S,
                    client_name = item["client_name"].S,
                });
            }
            return clientItemList;
        }

        public async Task<bool> DeleteClientItemAsync(string pk, string sk)
        {
            var request = new DeleteItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "pk", new AttributeValue { S = pk } },
                    { "sk", new AttributeValue { S = sk } },
                }
            };

            var response = await _dynamoDbClient.DeleteItemAsync(request);
            return response.HttpStatusCode == System.Net.HttpStatusCode.OK;

        }

    }

}
