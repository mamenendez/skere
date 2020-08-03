using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace DynamoDB.libs.DynamoDB
{
    public class PutItem : IPutItem
    {
        private readonly IAmazonDynamoDB _dynamoClient;
     //Test
        public PutItem(IAmazonDynamoDB dynamoClient)
        {
            _dynamoClient = dynamoClient;
        }

        public async Task AddNewEntry(string Email, string Uid, string Nombre, string Apellido, string Rol, string Password, string CodigoInvitado, bool Valido)
        {
            var queryRequest = RequestBuilder( Email,  Uid,  Nombre,  Apellido,  Rol,  Password,  CodigoInvitado,  Valido);
            await PutItemAsync(queryRequest);
        }

        private PutItemRequest RequestBuilder(string Email, string Uid, string Nombre, string Apellido, string Rol, string Password, string CodigoInvitado, bool Valido)
        {
            var item = new Dictionary<string, AttributeValue>
                    {
                        {"email", new AttributeValue {S = Email}},
                        {"uid", new AttributeValue {S = Uid}},
                        {"nombre", new AttributeValue {S = Nombre}},
                        {"apellido", new AttributeValue {S = Apellido}},
                        {"rol", new AttributeValue {S = Rol}},
                        {"password", new AttributeValue {S = Password}},
                        {"codigoInvitado", new AttributeValue {S = CodigoInvitado}},
                        {"valido", new AttributeValue {BOOL = Valido } }
                    };

            return new PutItemRequest
            {
                TableName = "Ahorrista",
                Item = item
            };
        }

        private async Task PutItemAsync(PutItemRequest request)
        {
            //Cuidado, agregar un control antes de insertar 
            request.ReturnValues = ReturnValue.ALL_OLD;

            var response = await _dynamoClient.PutItemAsync(request);
           
            if (response.Attributes != null && response.Attributes.Count > 0)
            {
                // It was an update
            }
            else

            {
                // It was an insert
            }
        
        }

    }
}
