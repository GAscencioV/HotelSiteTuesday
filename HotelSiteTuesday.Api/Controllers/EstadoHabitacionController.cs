using HotelSiteTuesday.Api.Dtos.EstadoHabitacion;
using HotelSiteTuesday.Api.Dtos.Habitacion;
using HotelSiteTuesday.Api.Models;
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

        [HttpGet("GetEstadoHabitacion")]
        public IActionResult Get()
        {
            var estadohabitacion = this.estadoHabitacionRepository.GetEntities().Select(cd => new EstadoHabitacionGetModel()
            {
                IdEstadoHabitacion = cd.IdEstadoHabitacion,
                Descripcion = cd.Descripcion,
            });

            return Ok(estadohabitacion);
        }

        [HttpPost("SaveEstadoHabitacion")]
        public IActionResult Post([FromBody] EstadoHabitacionAddDto habitacionAddModel)
        {
            this.estadoHabitacionRepository.Save(new Domain.Entities.EstadoHabitacion()
            {
                IdEstadoHabitacion = habitacionAddModel.IdEstadoHabitacion,
                Descripcion = habitacionAddModel.Descripcion
            });

            return Ok("El estado de la habitacion ha sido guardado correctamente.");
        }

        [HttpPost("UpdateEstadoHabitacion")]
        public IActionResult Put([FromBody] EstadoHabitacionUpdateDto estadoHabitacionUpdate)
        {
            this.estadoHabitacionRepository.Update(new EstadoHabitacion()
            {
                IdEstadoHabitacion = estadoHabitacionUpdate.IdEstadoHabitacion,
                Descripcion = estadoHabitacionUpdate.Descripcion
            });

            return Ok("El estado de la habitacion ha sido actualizado correctamente.");
        }

        [HttpDelete("RemoveEstadoHabitacion")]
        public IActionResult Remove([FromBody] EstadoHabitacionRemoveDto estadoHabitacionRemove)
        {
            this.estadoHabitacionRepository.Remove(new EstadoHabitacion()
            {
                IdEstadoHabitacion = estadoHabitacionRemove.IdEstadoHabitacion, 
            });

            return Ok("El estado de la habitacion ha sido eliminado correctamente.");
        }
    }
}
