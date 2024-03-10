using HotelSiteTuesday.Api.Models;
using HotelSiteTuesday.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelSiteTuesday.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        [HttpGet("GetUsuarios")]
        public IActionResult Get()
        {
            var usuarios = usuarioRepository.GetEntities().Select(us => new UsuarioAddModel() 
            {
                nombreCompleto = us.NombreCompleto,
                clave = us.Clave,
                correo = us.Correo,
                rolUsuarioId = us.IdRolUsuario,
                usuarioID = us.IdUsuario
            });
            return Ok(usuarios);
        }


        [HttpGet("GetUsuariosById")]
        public IActionResult Get(int id)
        {
            var usuarios = usuarioRepository.GetEntity(id);
            return Ok(usuarios);
        }


        [HttpPost("SaveUsuario")]
        public void Post([FromBody] UsuarioAddModel usuarioAddModel)
        {
            this.usuarioRepository.Save(new Domain.Entities.Usuario() 
            {
                IdUsuario = usuarioAddModel.usuarioID,
                NombreCompleto = usuarioAddModel.nombreCompleto,
                Correo = usuarioAddModel.correo,
                Clave = usuarioAddModel.clave,
                IdRolUsuario = usuarioAddModel.rolUsuarioId
            });
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
