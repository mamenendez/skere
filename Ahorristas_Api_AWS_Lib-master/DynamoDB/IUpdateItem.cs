using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DynamoDB.libs.Models;

namespace DynamoDB.libs.DynamoDB
{
    public interface IUpdateItem
    {
        Task<Item> Update(string Email, string Uid, string Nombre, string Apellido, string Rol, string Password);
    }
}
