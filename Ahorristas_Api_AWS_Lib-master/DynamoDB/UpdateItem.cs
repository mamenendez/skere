using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using DynamoDB.libs.Models;

namespace DynamoDB.libs.DynamoDB
{
    public class UpdateItem : IUpdateItem
    {

        private readonly IGetItem _getItem;
        private static readonly string tableName = "Ahorrista";
        private readonly IAmazonDynamoDB _dynamoDbClient;

        public UpdateItem(IGetItem getItem, IAmazonDynamoDB dynamoDbClient)
        {
            _getItem = getItem;
            _dynamoDbClient = dynamoDbClient;
        }

        public async Task<Item> Update(string Email, string Uid, string Nombre, string Apellido, string Rol, string Password)
        {
            var response = await _getItem.GetItems(Email);

            var current_nombre = response.Items.Select(p => p.Nombre).FirstOrDefault();
            var current_apellido = response.Items.Select(p => p.Apellido).FirstOrDefault();
            var current_rol = response.Items.Select(p => p.Rol).FirstOrDefault();
            var current_password = response.Items.Select(p => p.Password).FirstOrDefault();


    
            var request = RequestBuilder(current_nombre, current_apellido, current_rol, current_password,Email,Uid,Nombre,Apellido,Rol,Password);

            var result = await UpdateItemAsync(request);

            return new Item
            {

                Email = result.Attributes["email"].S,
                Uid = result.Attributes["uid"].S,
                Nombre = result.Attributes["nombre"].S,
                Apellido = result.Attributes["apellido"].S,
                Rol = result.Attributes["rol"].S,
                Password = result.Attributes["password"].S
                
            };
        }

        private UpdateItemRequest RequestBuilder(string current_nombre, string current_apellido, string current_rol, string current_password, string Email, string Uid, string Nombre, string Apellido, string Rol, string Password)
        {
            var request = new UpdateItemRequest
            {
                Key = new Dictionary<string, AttributeValue>
                    {
                        {
                            "Email", new AttributeValue
                            {
                                S = Email
                            }
                        }
                    },
           
                
                ExpressionAttributeNames = new Dictionary<string, string>
                    {
                        {"#N", "Nombre"},
                        {"#A", "Apellido"},
                        {"#R", "Rol"},
                        {"#P", "Password"}
                    },
            
                
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                {
                        { ":newnombre", new AttributeValue {S = Nombre }},
                        { ":currnombre", new AttributeValue {S = current_nombre }},

                        { ":newapellido", new AttributeValue {S = Apellido }},
                        { ":currapellido", new AttributeValue {S = current_apellido }},

                        { ":newrol", new AttributeValue {S = Rol }},
                        { ":currrol", new AttributeValue {S = current_rol }},

                        { ":newpassword", new AttributeValue {S = Password }},
                        { ":currpassword", new AttributeValue {S = current_password }}
                },

                
                UpdateExpression = "SET #N = :newnombre ,#A = :newapellido ,#R = :newrol, #P = :newpassword",
          
                // ConditionExpression = "#P = :currprice",

                TableName = tableName,
                ReturnValues = "ALL_NEW"
            };

            return request;

        }

        private async Task<UpdateItemResponse> UpdateItemAsync(UpdateItemRequest request)
        {
            var response = await _dynamoDbClient.UpdateItemAsync(request);

            return response;
        }
    }

}
