using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamoDB.libs.DynamoDB;
using Microsoft.AspNetCore.Mvc;



namespace Ahorrista_Api_AWS.Controllers
{
    [ApiController]
    [Route("api/Ahorrista")]
    public class AhorristaController : ControllerBase
    {
        private readonly IPutItem _putAhorrista;
        private readonly IGetItem _getAhorrista;
        private readonly IUpdateItem _updateAhorrista;
        private readonly IDeleteItem _deleteAhorrista;

        public AhorristaController(IPutItem putAhorrista, IGetItem getAhorrista, IUpdateItem updateAhorrista, IDeleteItem removeAhorrista)
        {

            _putAhorrista = putAhorrista;
            _getAhorrista = getAhorrista;
            _updateAhorrista = updateAhorrista;
            _deleteAhorrista = removeAhorrista;

        } 

    
        [HttpPost]
        [Route("put")]
        public IActionResult PutItem([FromQuery] string Email, string Uid, string Nombre, string Apellido, string Rol, string Password, string CodigoInvitado, bool Valido)
        { 
            Uid = Guid.NewGuid().ToString();

            _putAhorrista.AddNewEntry(Email, Uid, Nombre, Apellido, Rol, Password, CodigoInvitado, Valido);

            return Ok();
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetItems([FromQuery] string Email)
        {
            var response = await _getAhorrista.GetItems(Email);

            return Ok(response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateItem([FromQuery] string Email, string Uid, string Nombre, string Apellido, string Rol, string Password)
        {
            var response = await _updateAhorrista.Update(Email, Uid, Nombre, Apellido, Rol, Password);

            return Ok(response);
        }

      
        
        
        [HttpDelete]
        [Route("remove")]
        public IActionResult DeleteItem([FromQuery] string Email)
        {
            _deleteAhorrista.RemoveItem(Email);

            return Ok();
        }

    }
}
