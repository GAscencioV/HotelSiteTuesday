using HotelSiteTuesday.Api.Dtos.EstadoHabitacion;
using HotelSiteTuesday.Api.Dtos.Habitacion;
using HotelSiteTuesday.Api.Models;
using HotelSiteTuesday.Api.Models.EstadoHabitacion;
using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("GetEstadosHabitaciones")]
        public IActionResult Get()
        {
            var estadosHabitacion = this.estadoHabitacionRepository.GetEntities()
                .Select(cd => new EstadoHabitacionGetModel()
            {
                IdEstadoHabitacion = cd.IdEstadoHabitacion,
                Descripcion = cd.Descripcion,
            });

            return Ok(estadosHabitacion);
        }

        [HttpPost("SaveEstadoHabitacion")]
        public IActionResult Post([FromBody] EstadoHabitacionAddDto estadoHabitacionAddModel)
        {
            var estadosHabitacion = new EstadoHabitacion
            {
                IdEstadoHabitacion = estadoHabitacionAddModel.IdEstadoHabitacion,
                Descripcion = estadoHabitacionAddModel.Descripcion
            };

            estadoHabitacionRepository.Save(estadosHabitacion);

            return Ok("El estado de la habitacion ha sido guardado correctamente.");
        }

        [HttpPost("UpdateEstadoHabitacion")]
        public IActionResult Put([FromBody] EstadoHabitacionUpdateDto estadoHabitacionUpdate)
        {
            var estadoshabitacion = new EstadoHabitacion
            {
                IdEstadoHabitacion = estadoHabitacionUpdate.IdEstadoHabitacion,
                Descripcion = estadoHabitacionUpdate.Descripcion
            };

            estadoHabitacionRepository.Update(estadoshabitacion);

            return Ok("El estado de la habitacion ha sido actualizado correctamente.");
        }

        [HttpDelete("RemoveEstadoHabitacion")]
        public IActionResult Remove([FromBody] EstadoHabitacionRemoveDto estadoHabitacionRemove)
        {
            estadoHabitacionRepository.Remove(new EstadoHabitacion()
            {
                IdEstadoHabitacion = estadoHabitacionRemove.IdEstadoHabitacion, 
            });

            return Ok("El estado de la habitacion ha sido eliminado correctamente.");
        }
    }
}
