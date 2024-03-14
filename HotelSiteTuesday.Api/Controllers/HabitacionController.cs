using HotelSiteTuesday.Api.Dtos.Habitacion;
using HotelSiteTuesday.Api.Models;
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

        [HttpGet("GetHabitacion")]
        public IActionResult Get()
        {
            var habitacion = this.habitacionRepository.GetEntities().Select(cd => new HabitacionGetModel()

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

        //I need to keep looking for a better way to filter those requests. 
        [HttpGet("GetHabitacionByEstadoHabitacion")]
        public IActionResult GetHabitacionByEstadoHabitacion(int IdEstadoHabitacion) 
        {
            var habitacionbyEstado = this.habitacionRepository.GetHabitacionByEstadoHabitacion(IdEstadoHabitacion);

            return Ok(habitacionbyEstado);
        }

        [HttpGet("GetHabitacionByPiso")]
        public IActionResult GetHabitacionByPiso(int IdPiso)
        {
            var habitacionbyPiso = this.habitacionRepository.GetHabitacionByPiso(IdPiso);

            return Ok(habitacionbyPiso);
        }


        [HttpGet("GetHabitacionByCategoria")]
        public IActionResult GetByCategoria(int IdCategoria)
        {
            var habitacionbyHabitacion = this.habitacionRepository.GetHabitacionByCategoria(IdCategoria);

            return Ok(habitacionbyHabitacion);
        }


        [HttpPost("SaveHabitacion")]
        public IActionResult Post([FromBody] HabitacionAddDto habitacionAddModel)
        {
            this.habitacionRepository.Save(new Domain.Entities.Habitacion() 
            {
                Numero = habitacionAddModel.Numero,
                Detalle = habitacionAddModel.Detalle,
                Precio = habitacionAddModel.Precio,
            });

            return Ok("Habitacion guardada correctamente.");
        }

        [HttpPost("UpdateHabitacion")]
        public IActionResult Put([FromBody] HabitacionUpdateDto habitacionUpdate)
        {
            this.habitacionRepository.Update(new Habitacion() 
            {
                IdHabitacion = habitacionUpdate.IdHabitacion,
                Numero = habitacionUpdate.Numero,
                Detalle = habitacionUpdate.Detalle,
                Precio = habitacionUpdate.Precio,
            });

            return Ok("Habitacion actualizada correctamente.");
        }

        [HttpDelete("RemoveHabitacion")]
        public IActionResult Remove([FromBody] HabitacionRemoveDto habitacionRemove)
        {
            this.habitacionRepository.Remove(new Habitacion()
            {
                IdHabitacion = habitacionRemove.IdHabitacion,
            });

            return Ok("Habitacion eliminada correctamente.");
        }
    }
}
