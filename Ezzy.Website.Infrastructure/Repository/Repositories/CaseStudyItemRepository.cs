using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Ezzy.Website.Infrastructure.Domain.Entities;
using Ezzy.Website.Infrastructure.Domain.Interfaces;
using static Ezzy.Website.Infrastructure.Domain.Entities.CaseStudyItem;

namespace Ezzy.Website.Infrastructure.Repository.Repositories
{
    public class CaseStudyItemRepository : ICaseStudyItemRepository
    {
        private const string TableName = "ezzysoft-maintable";
        private readonly IAmazonDynamoDB _dynamoDbClient;

        public CaseStudyItemRepository(IAmazonDynamoDB dynamoDBClient)
        {
            _dynamoDbClient = dynamoDBClient;
        }
        public async Task AddCaseStudyItemAsync(CaseStudyItem caseStudyItem)
        {
            if (caseStudyItem == null)
            {
                throw new ArgumentNullException(nameof(caseStudyItem));
            }
            var request = new PutItemRequest
            {
                TableName = TableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    {"pk", new AttributeValue{ S= caseStudyItem.pk} },
                    {"sk", new AttributeValue{ S= caseStudyItem.sk} },
                    { "author_role", new AttributeValue { S = caseStudyItem.author_role } },
                    { "client_name", new AttributeValue { S = caseStudyItem.client_name } },
                    { "overview", new AttributeValue { S = caseStudyItem.overview } },
                    { "service", new AttributeValue { S = caseStudyItem.service } },
                    { "testimony", new AttributeValue { S = caseStudyItem.testimony } },
                    { "what_we_did", new AttributeValue {M = new Dictionary<string, AttributeValue> 
                        {
                            { "custom_cms", new AttributeValue { S = caseStudyItem.what_we_did.custom_cms } },
                            { "frontend", new AttributeValue { S = caseStudyItem.what_we_did.frontend } },
                            { "infrastructure", new AttributeValue { S = caseStudyItem.what_we_did.infrastructure } },
                            { "seo", new AttributeValue { S = caseStudyItem.what_we_did.seo } }
                         }
                    }},
                    { "testimony_author", new AttributeValue { S = caseStudyItem.testimony_author } },
                    { "year", new AttributeValue { S = caseStudyItem.year } }
                }
            };  
            await _dynamoDbClient.PutItemAsync(request);
        }    
        public async Task<CaseStudyItem> GetCaseStudyItemAsync(string pk, string sk)
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
                    Console.WriteLine("CaseStudy retrieved successfully");
                    foreach(var attribute in response.Item)
                    {
                        Console.WriteLine($"{attribute.Key}: {attribute.Value.S}");
                    }

                }
                else
                {
                    Console.WriteLine("CaseStudy not found");
                }

                return new CaseStudyItem
                {
                    pk = response.Item["pk"].S,
                    sk = response.Item["sk"].S,
                    author_role = response.Item["author_role"].S,
                    client_name = response.Item["client_name"].S,
                    overview = response.Item["overview"].S,
                    service = response.Item["service"].S,
                    testimony = response.Item["testimony"].S,
                    testimony_author = response.Item["testimony_author"].S,
                    year = response.Item["year"].S, 
                    what_we_did = new WhatWeDid
                    {
                        custom_cms = response.Item["what_we_did"].M["custom_cms"].S,
                        frontend = response.Item["what_we_did"].M["frontend"].S,
                        infrastructure = response.Item["what_we_did"].M["infrastructure"].S,
                        seo = response.Item["what_we_did"].M["seo"].S,
                    },
                };

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Error Occured");
            return null;
        }

        public async Task<IReadOnlyCollection<CaseStudyItem>> GetAllCaseStudyItemsAsync()
        {
            var partitionKeyValue = "COMPANY#1";
            var sortKeyPrefix = "CASESTUDY#";

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
            var caseStudyList = new List<CaseStudyItem>();
            foreach (var item in response.Items)
            {
                caseStudyList.Add(new CaseStudyItem
                {
                    pk = (item["pk"].S),
                    sk = item["sk"].S,
                    author_role = item["author_role"].S,
                    client_name = item["client_name"].S,
                    overview = item["overview"].S,
                    service = item["service"].S,
                    testimony = item["testimony"].S,
                    testimony_author = item["testimony_author"].S,
                    what_we_did = new WhatWeDid
                    {
                        custom_cms = item["what_we_did"].M["custom_cms"].S,
                        frontend = item["what_we_did"].M["frontend"].S,
                        infrastructure = item["what_we_did"].M["infrastructure"].S,
                        seo = item["what_we_did"].M["seo"].S
                    },
                    year = item["year"].S,

                });
            }
            return caseStudyList;
        }

        public async Task<bool> DeleteCaseStudyItemAsync(string pk, string sk)
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
