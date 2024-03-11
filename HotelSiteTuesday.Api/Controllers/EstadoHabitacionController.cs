using HotelSiteTuesday.Api.Models;
using HotelSiteTuesday.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelSiteTuesday.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoHabitacionController : ControllerBase
    {
        private readonly IEstadoHabitacionRepository estadoHabitacionRepository;

        public EstadoHabitacionController(IEstadoHabitacionRepository estadoHabitacionRepository) 
        {
            this.estadoHabitacionRepository = estadoHabitacionRepository;
        }

        [HttpGet("GetEstadoHabitacion")]
        public IActionResult Get()
        {
            var estadohabitacion = this.estadoHabitacionRepository.GetEntities().Select(cd => new EstadoHabitacionAddModel()
            {
                IdEstadoHabitacion = cd.IdEstadoHabitacion,
                Descripcion = cd.Descripcion,
            });

            return Ok(estadohabitacion);
        }

        [HttpPost("SaveEstadoHabitacion")]
        public void Post([FromBody] EstadoHabitacionAddModel habitacionAddModel)
        {
            this.estadoHabitacionRepository.Save(new Domain.Entities.EstadoHabitacion()
            {
                IdEstadoHabitacion = habitacionAddModel.IdEstadoHabitacion,
                Descripcion = habitacionAddModel.Descripcion
            });
        }

        // PUT api/<EstadoHabitacionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EstadoHabitacionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
