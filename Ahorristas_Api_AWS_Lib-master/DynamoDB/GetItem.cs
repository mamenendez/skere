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
    public class GetItem : IGetItem
    {
        private readonly IAmazonDynamoDB _dynamoClient;

        public GetItem(IAmazonDynamoDB dynamoClient)
        {
            _dynamoClient = dynamoClient;
        }

        public async Task<DynamoTableItems> GetItems(string email)
        {
            var queryRequest = RequestBuilder(email);

            var result = await ScanAsync(queryRequest);

            return new DynamoTableItems
            {
                Items = result.Items.Select(Map).ToList()
            };
        }

        private Item Map(Dictionary<string, AttributeValue> result)
        {
            return new Item
            {
                Email = result["ReplyDateTime"].S,
                Uid = result["ReplyDateTime"].S,
                Nombre = result["ReplyDateTime"].S,
                Apellido = result["ReplyDateTime"].S,
                Rol = result["ReplyDateTime"].S,
                Password = result["ReplyDateTime"].S,
                CodigoInvitado = result["ReplyDateTime"].S,
                Valido = Convert.ToBoolean(result["ReplyDateTime"].BOOL)
            };
        }

        private async Task<ScanResponse> ScanAsync(ScanRequest request)
        {
            var response = await _dynamoClient.ScanAsync(request);

            return response;
        }

        private ScanRequest RequestBuilder(string email)
        {
            if (email == null)
            {
                return new ScanRequest
                {
                    TableName = "Ahorrista",
                };
            }

            return new ScanRequest
            {
                TableName = "Ahorrista",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
              {
                ":v_Email", new AttributeValue { S = email }}
        },
                FilterExpression = "email = :v_Email",
                ProjectionExpression = "Email, Uid, Nombre, Apellido, Rol, Password, CodigoInvitado, Valido"
            };
        }


    }
}
