using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DynamoDB.libs.DynamoDB
{
    public interface IPutItem
    {
        Task AddNewEntry(string Email, string Uid, string Nombre, string Apellido, string Rol, string Password, string CodigoInvitado, bool Valido);
    }
}

