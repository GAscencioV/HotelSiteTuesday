using HotelSiteTuesday.Api.DTO.RolUsuario;
using HotelSiteTuesday.Api.Models;
using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Interfaces;
using HotelSiteTuesday.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelSiteTuesday.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolUsuarioController : ControllerBase
    {
        private readonly IRolUsuarioRepository rolUsuarioRepository;

        public RolUsuarioController(IRolUsuarioRepository rolUsuarioRepository)
        {
            this.rolUsuarioRepository = rolUsuarioRepository;
        }
        // GET: api/<RolUsuarioController>
        [HttpGet("GetRolUsuario")]
        public IActionResult Get()
        {
            var rolUsuarios = rolUsuarioRepository.GetEntities().Select(rol => new RolUsuarioGetModel()
            {
                Descripcion = rol.Descripcion,
                IdRolUsuario = rol.idRolUsuario
            });
            return Ok(rolUsuarios);
        }

        // GET api/<RolUsuarioController>/5
        [HttpGet("GetRolUsuarioById")]
        public IActionResult Get(int id)
        {
            var rolUsuario = rolUsuarioRepository.GetEntity(id);
            return Ok(rolUsuario);
        }

        // POST api/<RolUsuarioController>
        [HttpPost("SaveRolUsuario")]
        public IActionResult Post([FromBody] RolUsuarioGetModel rolUsuarioAddModel)
        {
            this.rolUsuarioRepository.Save(new RolUsuario()
            {
                idRolUsuario = rolUsuarioAddModel.IdRolUsuario,
                Descripcion = rolUsuarioAddModel.Descripcion
            });
            return Ok("Rol Usuario Guardado Correctamente");
        }

        // PUT api/<RolUsuarioController>/5
        [HttpPost("UpdateRolUsuario")]
        public IActionResult Put([FromBody] RolUsuarioUpdateDto rolUsuarioUpdate)
        {
            this.rolUsuarioRepository.Update(new RolUsuario() 
            {
                idRolUsuario = rolUsuarioUpdate.id,
                Descripcion = rolUsuarioUpdate.Descripcion
            });
            return Ok("Rol Usuario Actualizado Correctamente");
        }

        // DELETE api/<RolUsuarioController>/5
        [HttpPost("RemoveUsuario")]
        public IActionResult Delete([FromBody] RolUsuarioRemoveDto rolUsuarioRemove)
        {
            this.rolUsuarioRepository.Remove(new RolUsuario()
            {
                idRolUsuario = rolUsuarioRemove.id
            });
            return Ok("Rol Usuario Eliminado Correctamente");
        }
    }
}
