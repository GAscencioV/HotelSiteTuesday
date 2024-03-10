using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Context;
using HotelSiteTuesday.Infraestructure.Core;
using HotelSiteTuesday.Infraestructure.Exceptions;
using HotelSiteTuesday.Infraestructure.Interfaces;
using HotelSiteTuesday.Infraestructure.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Repositories
{
    public class HabitacionRepository : BaseRepository<Habitacion>, IHabitacionRepository
    {
        private readonly HotelContext context;
        private readonly ILogger<HabitacionRepository> logger;

        public HabitacionRepository(HotelContext context, ILogger<HabitacionRepository> logger) : base (context)
        {
            this.logger = logger;
        }

        public override List<Habitacion> GetEntities() 
        {
            return base.GetEntities().Where(ca => !ca.Estado).ToList();
        }   

        public override void Update(Habitacion entity)
        {
            try
            {
                var HabitacionToUpdate = this.GetEntity(entity.IdHabitacion);

                HabitacionToUpdate.Numero = entity.Numero;
                HabitacionToUpdate.Detalle = entity.Detalle;
                HabitacionToUpdate.Precio = entity.Precio;
                HabitacionToUpdate.IdEstadoHabitacion = entity.IdEstadoHabitacion;
                HabitacionToUpdate.IdPiso = entity.IdPiso;
                HabitacionToUpdate.IdCategoria = entity.IdCategoria;

                this.context.Habitacion.Update(HabitacionToUpdate);
                this.context.SaveChanges();

            }

            catch (Exception ex)
            {
                this.logger.LogError("Error actualizando la habitacion", ex.ToString());   
            }
        }

        public override void Save(Habitacion entity)
        {
            try
            {
                if (context.Habitacion.Any(ca => ca.Numero == entity.Numero))
                    throw new HabitacionException("La habitacion se encuentra registrada.");

                this.context.Habitacion.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error creando la habitacion", ex.ToString());
            }
        }

        //Check the query in order to make sure that everything is OK
        public List<HabitacionModels> GetHabitacionByEstadoHabitacion(int IdEstadoHabitacion)
        {
            List<HabitacionModels> habitacion = new List<HabitacionModels>();

            try
            {
                habitacion = (from ha in this.context.Habitacion
                              join eha in this.context.EstadoHabitacion on ha.IdEstadoHabitacion equals eha.IdEstadoHabitacion
                              where ha.IdEstadoHabitacion == IdEstadoHabitacion
                              select new HabitacionModels()
                              {
                                  IdEstadoHabitacion = eha.IdEstadoHabitacion,
                                  Descripcion = eha.Descripcion,
                                  Numero = ha.Numero,
                                  Detalle = ha.Detalle,
                                  Precio = ha.Precio,
                                  IdPiso = ha.IdPiso,
                                  IdCategoria = ha.IdCategoria,

                              }).ToList();

                return habitacion;
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo los estado de habitacion", ex.ToString());
            }

            return habitacion;
        }

        //It's necessary to create a model of Piso and Categoria to implement those methods
        public List<HabitacionModels> GetHabitacionByPiso(int IdPiso)
        {
            throw new NotImplementedException();
        }

        public List<HabitacionModels> GetHabitacionByCategoria(int IdCategoria)
        {
            throw new NotImplementedException();
        }
    }
}
