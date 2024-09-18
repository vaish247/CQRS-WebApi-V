using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Ezzy.Website.Infrastructure.Domain.Entities;
using Ezzy.Website.Infrastructure.Domain.Interfaces;

namespace Ezzy.Website.Infrastructure.Repository.Repositories
{
    public class CompanyItemRepository : ICompanyItemRepository
    {
        private const string TableName = "ezzysoft-maintable";
        private readonly IAmazonDynamoDB _dynamoDbClient;

        public CompanyItemRepository(IAmazonDynamoDB dynamoDBClient)
        {
            _dynamoDbClient = dynamoDBClient;
        }
        public async Task AddCompanyItemAsync(CompanyItem companyItem)
        {
            if (companyItem == null)
            {
                throw new ArgumentNullException(nameof(companyItem));
            }
            var request = new PutItemRequest
            {
                TableName = TableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    {"pk", new AttributeValue{ S= companyItem.pk} },
                    {"sk", new AttributeValue{ S= companyItem.sk} },
                    {"description", new AttributeValue{ S= companyItem.description} },
                    {"email", new AttributeValue{ S= companyItem.email} },
                    {"logo", new AttributeValue{ S= companyItem.logo} },
                    {"name", new AttributeValue{ S= companyItem.name} },
                    {"service", new AttributeValue{ S= companyItem.service} },
                }
            };
            await _dynamoDbClient.PutItemAsync(request);
        }    
        public async Task<CompanyItem> GetCompanyItemAsync(string pk, string sk)
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
                    Console.WriteLine("Company retrieved successfully");
                    foreach(var attribute in response.Item)
                    {
                        Console.WriteLine($"{attribute.Key}: {attribute.Value.S}");
                    }

                }
                else
                {
                    Console.WriteLine("Company not found");
                }

                return new CompanyItem
                {
                    pk = response.Item["pk"].S,
                    sk = response.Item["sk"].S,
                    description = response.Item["description"].S,
                    email = response.Item["email"].S,
                    logo = response.Item["logo"].S,
                    name = response.Item["name"].S,
                    service = response.Item["service"].S,
                };

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Error Occured");
            return null;
        }

        public async Task<IReadOnlyCollection<CompanyItem>> GetAllCompanyItemsAsync()
        {
            var partitionKeyValue = "COMPANY#1";
            var sortKeyPrefix = "COMPANY#";

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
            var companyItemList = new List<CompanyItem>();
            foreach (var item in response.Items)
            {
                companyItemList.Add(new CompanyItem
                {
                    pk = (item["pk"].S),
                    sk = item["sk"].S,
                    description = (item["description"].S),
                    email = (item["email"].S),
                    logo = (item["logo"].S),
                    name = (item["name"].S),
                    service = (item["service"].S),
                });
            }
            return companyItemList;
        }

        public async Task<bool> DeleteCompanyItemAsync(string pk, string sk)
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
