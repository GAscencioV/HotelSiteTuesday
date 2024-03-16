
using HotelSiteTuesday.Api.Dtos;
using HotelSiteTuesday.Api.Dtos.Recepcion;
using HotelSiteTuesday.Api.Models;
using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelSiteTuesday.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionController : ControllerBase
    {
    
        private readonly IRecepcionRepository recepcionRepository;
        private readonly ILogger<RecepcionController> logger;

        public RecepcionController (IRecepcionRepository recepcionRepository)
        {
            this.recepcionRepository = recepcionRepository;
            this.logger = logger;
        }

        [HttpGet ("GetRecepcion")]
        public IActionResult Get()
        {
            var recepcion = this.recepcionRepository.GetEntities().Select(cd => new RecepcionGetModel()
            {
                IdRecepcion = cd.IdRecepcion,
                IdCliente = cd.IdCliente,
                IdHabitacion = cd.IdHabitacion,
                FechaEntrada = cd.FechaEntrada,
                FechaSalida = cd.FechaSalida,
                FechaCreacion = cd.FechaCreacion,
                FechaSalidaConfirmacion = cd.FechaSalidaConfirmacion,
                CostoPenalidad = cd.CostoPenalidad,
                PrecioInicial = cd.PrecioInicial,
                Adelanto = cd.Adelanto,
                PrecioRestante = cd.PrecioRestante,
                Estado = cd.Estado,
                Descripcion = cd.Descripcion,
                Observacion = cd.Observacion,
                TotalPagado = cd.TotalPagado,
                Nombre = cd.Nombre,
            });
            return Ok(recepcion);
        }


        // GET api/<GetRecepcionByCliente>/5
        [HttpGet("GetRecepcionByCliente/{idCliente}")]

        public IActionResult GetRecepcionByCliente(int idCliente)
        {
            try
            {
                var recepcionesCliente = this.recepcionRepository.GetRecepcionByCliente(idCliente);
                if (recepcionesCliente.Count == 0)
                    return NotFound("No se encontraron recepciones para el cliente especificado.");

                return Ok(recepcionesCliente);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al obtener recepciones por cliente", ex);
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }

        // GET api/<GetRecepcionByHabitacion>/5
        [HttpGet("GetRecepcionByHabitacion/{idHabitacion}")]
        public IActionResult GetRecepcionByHabitacion(int idHabitacion)
        {
            try
            {
                var recepcionesHabitacion = this.recepcionRepository.GetRecepcionByHabitacion(idHabitacion);
                if (recepcionesHabitacion.Count == 0)
                    return NotFound("No se encontraron recepciones para la habitación especificada.");

                return Ok(recepcionesHabitacion);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener recepciones por habitación");
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }

        // POST api/<SaveHabitacion>
        [HttpPost ("SaveHabitacion")]
        public IActionResult Post([FromBody] RecepcionAddDto recepcionAddModel)
        {
            this.recepcionRepository.Save(new Domain.Entities.Recepcion()

            {
                IdRecepcion = recepcionAddModel.IdRecepcion,
                IdCliente = recepcionAddModel.IdCliente,
                IdHabitacion = recepcionAddModel.IdHabitacion,
                Nombre = recepcionAddModel.Nombre,
                FechaEntrada = recepcionAddModel.FechaEntrada,
                FechaSalida = recepcionAddModel.FechaSalida,
                FechaSalidaConfirmacion = recepcionAddModel.FechaSalidaConfirmacion,
                FechaCreacion = recepcionAddModel.FechaCreacion,
                PrecioInicial = recepcionAddModel.PrecioInicial,
                CostoPenalidad = recepcionAddModel.CostoPenalidad,
                Adelanto = recepcionAddModel.Adelanto,
                PrecioRestante = recepcionAddModel.PrecioRestante,
                Observacion = recepcionAddModel.Observacion,
                Descripcion = recepcionAddModel.Descripcion,
                TotalPagado = recepcionAddModel.TotalPagado,
                Estado = recepcionAddModel.Estado
            });
            return Ok("Recepcion Guardada correctamente");
        }

        // PUT api/<UpdateRecepcion>/5
        [HttpPut("UpdateHabitacion")]
        public IActionResult Put([FromBody] RecepcionUpdateDto recepcionUpdate)
        {
            this.recepcionRepository.Update(new Recepcion()

            {
                IdRecepcion = recepcionUpdate.IdRecepcion,
                IdCliente = recepcionUpdate.IdCliente,
                IdHabitacion = recepcionUpdate.IdHabitacion,
                Nombre = recepcionUpdate.Nombre,
                FechaEntrada = recepcionUpdate.FechaEntrada,
                FechaSalida = recepcionUpdate.FechaSalida,
                FechaCreacion = recepcionUpdate.FechaCreacion,
                FechaSalidaConfirmacion = recepcionUpdate.FechaSalidaConfirmacion,
                PrecioInicial = recepcionUpdate.PrecioInicial,
                CostoPenalidad = recepcionUpdate.CostoPenalidad,
                Adelanto = recepcionUpdate.Adelanto,
                Descripcion = recepcionUpdate.Descripcion,
                PrecioRestante = recepcionUpdate.PrecioRestante,
                TotalPagado = recepcionUpdate.TotalPagado,
                Estado = recepcionUpdate.Estado,
                Observacion = recepcionUpdate.Observacion
            });
            return Ok("Recepcion actualizada correctamente");
        }

        // DELETE api/<DeleteController>/5
        [HttpPut("DeleteHabitacion")]
        public IActionResult Remove([FromBody] RecepcionRemoveDto recepcionRemove)
        {
            this.recepcionRepository.Remove(new Recepcion()

            {
                IdRecepcion = recepcionRemove.IdRecepcion
            });
            return Ok("Recepcion eliminada correctamente");
        }
    }
}
