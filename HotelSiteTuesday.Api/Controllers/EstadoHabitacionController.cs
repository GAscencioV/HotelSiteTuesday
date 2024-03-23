using HotelSiteTuesday.Api.Dtos.EstadoHabitacion;
using HotelSiteTuesday.Api.Dtos.Habitacion;
using HotelSiteTuesday.Api.Models;
using HotelSiteTuesday.Api.Models.EstadoHabitacion;
using HotelSiteTuesday.Application.Service;
using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelSiteTuesday.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoHabitacionController : ControllerBase
    {
        private readonly IEstadoHabitacionServices estadohabitacionService;

        public EstadoHabitacionController(IEstadoHabitacionServices estadoHabitacionService)
        {
            this.estadohabitacionService = estadoHabitacionService;
        }

        [HttpGet("GetEstadosHabitaciones")]
        public IActionResult Get()
        {
            var result = this.estadohabitacionService.GetEstadosHabitaciones();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpGet("GetEstadoHabitacionById")]
        public IActionResult Get(int id)
        {
            var result = this.estadohabitacionService.GetEstadosHabitacionesbyId(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("SaveEstadoHabitacion")]
        public IActionResult Post([FromBody] Application.Dtos.EstadoHabitacion.EstadoHabitacionAddDto estadoHabitacionAddModel)
        {
            var result = this.estadohabitacionService.SaveEstadoHabitacion(estadoHabitacionAddModel);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("UpdateEstadoHabitacion")]
        public IActionResult Put([FromBody] Application.Dtos.EstadoHabitacion.EstadoHabitacionUpdateDto estadoHabitacionUpdate)
        {
            var result = this.estadohabitacionService.UpdateEstadoHabitacion(estadoHabitacionUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("RemoveEstadoHabitacion")]
        public IActionResult Remove([FromBody] Application.Dtos.EstadoHabitacion.EstadoHabitacionRemoveDto estadoHabitacionRemove)
        {
            var result = this.estadohabitacionService.RemoveEstadoHabitacion(estadoHabitacionRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
