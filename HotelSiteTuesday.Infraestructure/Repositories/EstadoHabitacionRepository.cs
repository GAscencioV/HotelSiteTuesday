﻿using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Domain.Repository;
using HotelSiteTuesday.Infraestructure.Context;
using HotelSiteTuesday.Infraestructure.Core;
using HotelSiteTuesday.Infraestructure.Exceptions;
using HotelSiteTuesday.Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Repositories
{
    public class EstadoHabitacionRepository : BaseRepository<EstadoHabitacion>, IEstadoHabitacionRepository
    {
        private readonly HotelContext context;
        private readonly ILoggerBase logger;
        private readonly Action<string> errorMethod;

        public EstadoHabitacionRepository(HotelContext context, ILoggerBase logger) : base (context)
        {
            this.context = context;
            this.logger = logger;
            errorMethod = logger.LogError;
        }

        public override List<EstadoHabitacion> GetEntities()
        {
            return base.GetEntities().Where(ca => !ca.Estado).ToList();
        }

        public override void Update(EstadoHabitacion entity)
        {
            try
            {
                var EstadoHabitacionToUpdate = this.GetEntity(entity.IdEstadoHabitacion);

                EstadoHabitacionToUpdate.Descripcion = entity.Descripcion;

                this.context.EstadoHabitacion.Update(EstadoHabitacionToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorMethod("Error actualizando la descripcion de la Habitacion" + ex.ToString());
            }
        }

        public override void Remove(EstadoHabitacion entity)
        {
            EstadoHabitacion estadoHabitacionToRemove = this.GetEntity(entity.IdEstadoHabitacion);

            try
            {
                if (estadoHabitacionToRemove is null)
                    throw new EstadoHabitacionException("No se puede eliminar el estado de habitación, se encuentra asociado a una habitación.");

                else
                {
                    estadoHabitacionToRemove.IdEstadoHabitacion = entity.IdEstadoHabitacion;

                    context.EstadoHabitacion.Remove(estadoHabitacionToRemove);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                errorMethod("Error al eliminar el estado de habitación" + ex.ToString());
            }
        }

        public override void Save(EstadoHabitacion entity)
        {
            try
            {
                if (context.EstadoHabitacion.Any(ca => ca.Descripcion == entity.Descripcion))
                    throw new EstadoHabitacionException("La habitacion se encuentra registrada.");

                this.context.EstadoHabitacion.Add(entity);
                this.context.SaveChanges(); 
            }
            catch (Exception ex)
            {
                errorMethod("Error creando el estado de la habitacion" + ex.ToString());
            }
        }
    }
}
