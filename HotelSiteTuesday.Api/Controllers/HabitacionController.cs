using HotelSiteTuesday.Api.Models;
using HotelSiteTuesday.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelSiteTuesday.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private readonly IHabitacionRepository habitacionRepository;

        public HabitacionController(IHabitacionRepository habitacionRepository)
        {
            this.habitacionRepository = habitacionRepository;
        }

        [HttpGet("GetHabitacion")]
        public IActionResult Get()
        {
            var habitacion = this.habitacionRepository.GetEntities().Select(cd => new HabitacionAddModel()
            {
                IdHabitacion = cd.IdHabitacion,
                Numero = cd.Numero,
                Detalle = cd.Detalle,
                Precio = cd.Precio,
            });
            return Ok(habitacion);
        }

        [HttpGet("GetHabitacionByEstadoHabitacion")]
        public IActionResult Get(int IdEstadoHabitacion) 
        {
            var habitacionbyEstado = this.habitacionRepository.GetEntity(IdEstadoHabitacion);
            return Ok(habitacionbyEstado);
        }

        [HttpPost("SaveHabitacion")]
        public void Post([FromBody] HabitacionAddModel habitacionAddModel)
        {
            this.habitacionRepository.Save(new Domain.Entities.Habitacion() 
            {
                Numero = habitacionAddModel.Numero,
                Detalle = habitacionAddModel.Detalle,
                Precio = habitacionAddModel.Precio,
            });
        }

        // PUT api/<HabitacionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HabitacionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
