using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DynamoDB.libs.Models;


namespace DynamoDB.libs.DynamoDB
{
    public interface IDeleteItem
    {
        Task RemoveItem(string email);
    }
}
