using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using DynamoDB.libs.Models;


namespace DynamoDB.libs.DynamoDB
{
    public class DeleteItem : IDeleteItem
    {
        private readonly IAmazonDynamoDB _dynamoClient;

        public DeleteItem(IAmazonDynamoDB dynamoClient)
        {
            _dynamoClient = dynamoClient;
        }

        public async Task RemoveItem(string email)
        {
            var queryRequest = RequestBuilder(email);
            await DeleteItemAsync(queryRequest);
        }

        private DeleteItemRequest RequestBuilder(string email)
        {
            var item = new Dictionary<string, AttributeValue>
                    {
                        {"email", new AttributeValue {N = email}}
                    };

            return new DeleteItemRequest
            {
                TableName = "Ahorrista",
                Key = item
            };
        }
        private async Task DeleteItemAsync(DeleteItemRequest request)
        {
            await _dynamoClient.DeleteItemAsync(request);
        }

    }


}

