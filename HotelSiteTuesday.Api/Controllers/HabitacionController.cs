using HotelSiteTuesday.Api.Dtos.Habitacion;
using HotelSiteTuesday.Api.Models;
using HotelSiteTuesday.Api.Models.Habitacion;
using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [HttpGet("GetHabitaciones")]
        public IActionResult Get()
        {
            var habitacion = habitacionRepository.GetEntities().
                Select(cd => new HabitacionGetModel()

            {
                IdHabitacion = cd.IdHabitacion,
                Numero = cd.Numero,
                Detalle = cd.Detalle,
                Precio = cd.Precio,
                IdEstadoHabitacion = cd.IdEstadoHabitacion,
                IdPiso = cd.IdPiso,
                IdCategoria = cd.IdCategoria,
            });

            return Ok(habitacion);
        }

        [HttpPost("SaveHabitacion")]
        public IActionResult Post([FromBody] HabitacionAddDto habitacionAddModel)
        {
            var habitacion = new Domain.Entities.Habitacion()
            {
                Numero = habitacionAddModel.Numero,
                Detalle = habitacionAddModel.Detalle,
                Precio = habitacionAddModel.Precio,
            };

            habitacionRepository.Save(habitacion);

            return Ok("Habitacion guardada correctamente.");
        }

        [HttpPost("UpdateHabitacion")]
        public IActionResult Put([FromBody] HabitacionUpdateDto habitacionUpdate)
        {
            var habitacion = new Habitacion
            {
                IdHabitacion = habitacionUpdate.IdHabitacion,
                Numero = habitacionUpdate.Numero,
                Detalle = habitacionUpdate.Detalle,
                Precio = habitacionUpdate.Precio,
            };

            habitacionRepository.Update(habitacion);

            return Ok("Habitacion actualizada correctamente.");
        }

        [HttpDelete("RemoveHabitacion")]
        public IActionResult Remove([FromBody] HabitacionRemoveDto habitacionRemove)
        {
            habitacionRepository.Remove(new Habitacion()
            {
                IdHabitacion = habitacionRemove.IdHabitacion,
            });

            return Ok("Habitacion eliminada correctamente.");
        }

        //I need to keep looking for a better way to filter those requests. 
        [HttpGet("GetHabitacionByEstadoHabitacion")]
        public IActionResult GetHabitacionByEstadoHabitacion(int IdEstadoHabitacion) 
        {
            var habitacionbyEstado = this.habitacionRepository.GetHabitacionByEstadoHabitacion(IdEstadoHabitacion);

            if (habitacionbyEstado.Any())
            {
                return Ok(habitacionbyEstado);
            }

            return NotFound("No se encontraron habitaciones con el estado especificado.");
        }

        [HttpGet("GetHabitacionByPiso")]
        public IActionResult GetHabitacionByPiso(int IdPiso)
        {
            var habitacionbyPiso = this.habitacionRepository.GetHabitacionByPiso(IdPiso);

            if (habitacionbyPiso.Any())
            {
                return Ok(habitacionbyPiso);
            }

            return NotFound("No se encontraron los pisos con el estado especificado.");
        }


        [HttpGet("GetHabitacionByCategoria")]
        public IActionResult GetByCategoria(int IdCategoria)
        {
            var habitacionbyHabitacion = this.habitacionRepository.GetHabitacionByCategoria(IdCategoria);

            if (habitacionbyHabitacion.Any())
            {
                return Ok(habitacionbyHabitacion);
            }

            return NotFound("No se encontraron las categorias con el estado especificado.");
        }

    }
}
