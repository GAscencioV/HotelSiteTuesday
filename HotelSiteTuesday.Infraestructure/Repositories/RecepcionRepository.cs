using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Domain.Repository;
using HotelSiteTuesday.Infraestructure.Context;
using HotelSiteTuesday.Infraestructure.Core;
using HotelSiteTuesday.Infraestructure.Exceptions;
using HotelSiteTuesday.Infraestructure.Extentions;
using HotelSiteTuesday.Infraestructure.Interfaces;
using HotelSiteTuesday.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelSiteTuesday.Infraestructure.Repositories
{
    public class RecepcionRepository : BaseRepository<Recepcion>, IRecepcionRepository
    {
        private readonly HotelContext context;
        private readonly ILogger<RecepcionRepository> logger;

        public RecepcionRepository(HotelContext context, ILogger<RecepcionRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }


        public override  List<Recepcion> GetEntities()
        {
            return base.GetEntities().Where(ca => !(bool)ca.Estado).ToList();
        }

        public override void Update (Recepcion entity)
        {
            try
            {
                var recepcionToUpdate = this.GetEntity(entity.IdRecepcion);

                if (recepcionToUpdate is null)
                {
                    throw new RecepcionException("La Recepcion no existe.");

                    recepcionToUpdate.IdRecepcion = entity.IdRecepcion;
                    recepcionToUpdate.IdCliente = entity.IdCliente;
                    recepcionToUpdate.IdHabitacion = entity.IdHabitacion;
                    recepcionToUpdate.Nombre = entity.Nombre;
                    recepcionToUpdate.FechaEntrada = entity.FechaEntrada;
                    recepcionToUpdate.FechaSalida = entity.FechaSalida;
                    recepcionToUpdate.FechaSalidaConfirmacion = entity.FechaSalidaConfirmacion;
                    recepcionToUpdate.FechaCreacion = entity.FechaCreacion;
                    recepcionToUpdate.PrecioInicial = entity.PrecioInicial;
                    recepcionToUpdate.Adelanto = entity.Adelanto;
                    recepcionToUpdate.CostoPenalidad = entity.CostoPenalidad;
                    recepcionToUpdate.PrecioRestante = entity.PrecioRestante;
                    recepcionToUpdate.Descripcion = entity.Descripcion;
                    recepcionToUpdate.TotalPagado = entity.TotalPagado;
                    recepcionToUpdate.Estado = entity.Estado;
                    recepcionToUpdate.Observacion = entity.Observacion;

                    this.context.Recepcion.Update(recepcionToUpdate);
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actualizando la Recepcion", ex.ToString());
            } 
        }

        public override void Remove(Recepcion entity)
        {
            try
            {
                Recepcion recepcionToRemove = this.GetEntity(entity.IdRecepcion);

                if (recepcionToRemove is null)
                    throw new RecepcionException("No se encuentra la categoria.");

                else
                {
                    recepcionToRemove.IdRecepcion = entity.IdRecepcion;
                    this.context.Recepcion.Remove(recepcionToRemove);
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar la recepcion", ex.ToString());
            
            }
        }

        public override void Save(Recepcion entity)
        {
            try
            {
                if (context.Recepcion.Any(ca => ca.IdRecepcion == entity.IdRecepcion))
                    throw new RecepcionException("El Id ya esta registrado");

                this.context.Recepcion.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error guardando el campo", ex.ToString());
            }
        }

        public List<RecepcionModel> GetRecepcionByCliente(int idCliente)
        {
            List<RecepcionModel> recepciones = new List<RecepcionModel>();
            try
            {
                recepciones = (from recepcion in this.context.Recepcion
                               where recepcion.IdCliente == idCliente
                               select new RecepcionModel
                               {
                                   IdRecepcion = recepcion.IdRecepcion,
                                   Descripcion = $"Recepción del cliente {recepcion.Nombre}", 
                               }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error en recepcion", ex.ToString());
            }
            return recepciones;
        }

        public List<RecepcionModel> GetRecepcionByHabitacion(int idHabitacion)
        {
    
            List<RecepcionModel> recepciones = new List<RecepcionModel>();
            try
            {
                var query = this.context.Recepcion
                             .Where(recepcion => recepcion.IdHabitacion == idHabitacion)
                             .Select(recepcion => new RecepcionModel
                             {
                                 IdRecepcion = recepcion.IdRecepcion,
                                 Descripcion = $"Recepción de la habitación {idHabitacion}",
                             });

                recepciones = query.ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error en recepcion", ex.ToString());
            }
            return recepciones;
        }
    }

}

