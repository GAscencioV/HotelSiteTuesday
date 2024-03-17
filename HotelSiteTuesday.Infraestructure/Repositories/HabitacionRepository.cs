using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Context;
using HotelSiteTuesday.Infraestructure.Core;
using HotelSiteTuesday.Infraestructure.Exceptions;
using HotelSiteTuesday.Infraestructure.Interfaces;
using HotelSiteTuesday.Infraestructure.Models.Habitacion;
using static System.Formats.Asn1.AsnWriter;
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
        private readonly ILoggerBase logger;
        private readonly Action<string> errorMethod;

        public HabitacionRepository(HotelContext context, ILoggerBase logger) : base (context)
        {
            this.context = context;
            this.logger = logger;
            errorMethod = logger.LogError;
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

                if (HabitacionToUpdate is null)
                    throw new HabitacionException("La habitacion no existe.");

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
                errorMethod("Error actualizando la habitacion" + ex.ToString());   
            }
        }

        public override void Remove(Habitacion entity)
        {
            try
            {
                Habitacion habitacionToRemove = this.GetEntity(entity.IdHabitacion);

                if (habitacionToRemove is null)
                    throw new HabitacionException("No se encuentra la categoria.");

                else
                {
                    habitacionToRemove.IdHabitacion = entity.IdHabitacion;

                    this.context.Habitacion.Remove(habitacionToRemove);
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                errorMethod("Error al eliminar la habitación" + ex.ToString());
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
                errorMethod("Error creando la habitacion" + ex.ToString());
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
                errorMethod("Error obteniendo los estado de habitacion" + ex.ToString());
            }

            return habitacion;
        }

        //It's necessary to create a model of Piso and Categoria to implement those methods
        public List<HabitacionModels> GetHabitacionByPiso(int IdPiso)
        {
            List<HabitacionModels> habitacion = new List<HabitacionModels> ();

            try
            {
                habitacion = (from ha in this.context.Habitacion
                              join p in this.context.Piso on ha.IdPiso equals p.IdPiso
                              where ha.IdPiso == IdPiso
                              select new HabitacionModels()
                              {
                                  IdPiso = p.IdPiso,
                                  Descripcion = p.Descripcion,
                                  Numero = ha.Numero,
                                  Detalle = ha.Detalle,
                                  Precio = ha.Precio,
                                  IdCategoria = ha.IdCategoria,

                              }).ToList();

                return habitacion;
            }
            catch (Exception ex)
            {
                errorMethod("Error obteniendo las habitaciones por piso" + ex.ToString());
            }

            return habitacion;
        }

        public List<HabitacionModels> GetHabitacionByCategoria(int IdCategoria)
        {
            List<HabitacionModels> habitacion = new List<HabitacionModels>();

            try
            {
                habitacion = (from ha in this.context.Habitacion
                              join ca in this.context.Categoria on ha.IdCategoria equals ca.IdCategoria
                              where ha.IdCategoria == IdCategoria
                              select new HabitacionModels()
                              {
                                  IdCategoria = ca.IdCategoria,
                                  Descripcion = ca.Descripcion,
                                  Numero = ha.Numero,
                                  Detalle = ha.Detalle, 
                                  Precio = ha.Precio,
                                  IdPiso = ha.IdPiso,
                                  IdEstadoHabitacion = ha.IdEstadoHabitacion,

                              }).ToList();

                return habitacion;
            }
            catch (Exception ex)
            {
                errorMethod("Error obteniendo las habitaciones por categoria" + ex.ToString());
            }

            return habitacion;
        }
    }
}
