using HotelSiteTuesday.Api.DTO.Usuario;
using HotelSiteTuesday.Api.Models;
using HotelSiteTuesday.Domain.Entities;
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
            var usuarios = usuarioRepository.GetEntities().Select(us => new UsuarioGetModel() 
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
            var usuario = usuarioRepository.GetEntity(id);
            
            UsuarioGetModel usuarioGetModel = new UsuarioGetModel() 
            {
                usuarioID = usuario.IdUsuario,
                nombreCompleto = usuario.NombreCompleto,
                correo = usuario.Correo,
                clave = usuario.Clave,
                rolUsuarioId = usuario.IdRolUsuario
            
            };
            return Ok(usuarioGetModel);
        }


        [HttpPost("SaveUsuario")]
        public IActionResult Post([FromBody] UsuarioGetModel usuarioAddModel)
        {
            this.usuarioRepository.Save(new Usuario() 
            {
                NombreCompleto = usuarioAddModel.nombreCompleto,
                Correo = usuarioAddModel.correo,
                Clave = usuarioAddModel.clave,
                IdRolUsuario = usuarioAddModel.rolUsuarioId,
            });

            return Ok("Usuario creado correctamente.");
        }

        // PUT api/<UsuarioController>/5
        [HttpPost("UpdateUsuario")]
        public IActionResult Put([FromBody] UsuarioUpdateDto usuarioUpdate)
        {
            this.usuarioRepository.Update(new Usuario()
            {
                IdUsuario = usuarioUpdate.id,
                NombreCompleto = usuarioUpdate.nombreCompleto,
                Clave = usuarioUpdate.clave,
                IdRolUsuario = usuarioUpdate.rolUsuarioId
            });
            return Ok("Usuario actualizado correctamente.");
        }

        // DELETE api/<UsuarioController>/5
        [HttpPost("RemoveUsuario")]
        public IActionResult Delete([FromBody] UsuarioRemoveDto usuarioRemove)
        {
            this.usuarioRepository.Remove(new Usuario()
            {
                IdUsuario = usuarioRemove.id
            });
            return Ok("Usuario eliminado correctamente.");
        }
    }
}
