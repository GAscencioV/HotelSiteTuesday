using HotelSiteTuesday.Api.Models;
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
            var rolUsuarios = rolUsuarioRepository.GetEntities().Select(rol => new RolUsuarioAddModel()
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
        public void Post([FromBody] RolUsuarioAddModel rolUsuarioAddModel)
        {
            this.rolUsuarioRepository.Save(new Domain.Entities.RolUsuario()
            {
                idRolUsuario = rolUsuarioAddModel.IdRolUsuario,
                Descripcion = rolUsuarioAddModel.Descripcion
            });
        }

        // PUT api/<RolUsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RolUsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
