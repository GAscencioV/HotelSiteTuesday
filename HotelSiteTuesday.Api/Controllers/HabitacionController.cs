using HotelSiteTuesday.Api.Dtos.Habitacion;
using HotelSiteTuesday.Api.Models;
using HotelSiteTuesday.Api.Models.Habitacion;
using HotelSiteTuesday.Application.Contracts;
using HotelSiteTuesday.Application.Service;
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
        private readonly IHabitacionService habitacionService;
          
        public HabitacionController(IHabitacionService habitacionService)
        {
            this.habitacionService = habitacionService;
        }

        [HttpGet("GetHabitaciones")]
        public IActionResult Get()
        {
            var result = this.habitacionService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("GetHabitacionById")]
        public IActionResult Get(int id)
        {
            var result = this.habitacionService.Get(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("SaveHabitacion")]
        public IActionResult Post([FromBody] Application.Dtos.Habitacion.HabitacionAddDto habitacionAddModel)
        {
            var result = this.habitacionService.Save(habitacionAddModel);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("UpdateHabitacion")]
        public IActionResult Put([FromBody] Application.Dtos.Habitacion.HabitacionUpdateDto habitacionUpdate)
        {
            var result = this.habitacionService.Update(habitacionUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("RemoveHabitacion")]
        public IActionResult Remove([FromBody] Application.Dtos.Habitacion.HabitacionRemoveDto habitacionRemove)
        {
            var result = this.habitacionService.Remove(habitacionRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        //It needs to be implemented
        [HttpGet("GetHabitacionByEstadoHabitacion")]
        public IActionResult GetHabitacionByEstadoHabitacion(int IdEstadoHabitacion) 
        {
            var result = this.habitacionService.GetHabitacionByEstadoHabitacion(IdEstadoHabitacion);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("GetHabitacionByPiso")]
        public IActionResult GetHabitacionByPiso(int IdPiso)
        {
            var result = this.habitacionService.GetHabitacionByPiso(IdPiso);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpGet("GetHabitacionByCategoria")]
        public IActionResult GetByCategoria(int IdCategoria)
        {
            var result = this.habitacionService.GetHabitacionByCategoria(IdCategoria);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
