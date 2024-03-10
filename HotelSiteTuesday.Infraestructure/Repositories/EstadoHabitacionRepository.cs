using HotelSiteTuesday.Domain.Entities;
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
        private readonly ILogger<EstadoHabitacion> logger;

        public EstadoHabitacionRepository(HotelContext context, ILogger<EstadoHabitacion> logger) : base (context)
        {
            this.logger = logger;
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
                this.logger.LogError("Error actualizando la descripcion de la Habitacion", ex.ToString());
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
                this.logger.LogError("Error creando el estado de la habitacion", ex.ToString());
            }
        }
    }
}
