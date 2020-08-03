namespace DynamoDB.libs.Models
{
    public class Item
    {
        public string Email { get; set; }
        public string Uid { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rol { get; set; }
        public string Password { get; set; }
        public string CodigoInvitado { get; set; }
        public bool Valido { get; set; }
    }
}

/*
 string Email 
 string Uid
 string Nombre
 string Apellido
 string Rol
 string Password
 string CodigoInvitado
 bool Valido

              Email
              Uid
              Nombre
              Apellido
              Rol
              Password
              CodigoInvitado
              Valido
 
 string Email, string Uid, string Nombre, string Apellido, string Rol, string Password, string CodigoInvitado, bool Valido
 
 */
