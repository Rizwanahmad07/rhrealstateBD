using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Data
{
    public interface IDynamoDbIdGenerator
    {
        Task<int> GetNextIdAsync(string tableName);
    }

    public class DynamoDbIdGenerator : IDynamoDbIdGenerator
    {
        private readonly IAmazonDynamoDB _dynamoDbClient;
        private const string CountersTableName = "SystemCounters";

        public DynamoDbIdGenerator(IAmazonDynamoDB dynamoDbClient)
        {
            _dynamoDbClient = dynamoDbClient;
        }

        public async Task<int> GetNextIdAsync(string tableName)
        {
            var request = new UpdateItemRequest
            {
                TableName = CountersTableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "TableName", new AttributeValue { S = tableName } }
                },
                UpdateExpression = "ADD CurrentId :inc",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                {
                    { ":inc", new AttributeValue { N = "1" } }
                },
                ReturnValues = ReturnValue.UPDATED_NEW
            };

            var response = await _dynamoDbClient.UpdateItemAsync(request);
            
            if (response.Attributes.TryGetValue("CurrentId", out var attributeValue))
            {
                return int.Parse(attributeValue.N);
            }

            return 1;
        }
    }
}
