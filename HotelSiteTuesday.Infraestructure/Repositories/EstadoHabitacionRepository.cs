using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Context;
using HotelSiteTuesday.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Repositories
{
    public class EstadoHabitacionRepository : IEstadoHabitacionRepository
    {
        private readonly HotelContext context;

        public EstadoHabitacionRepository(HotelContext context)
        {
            this.context = context;
        }

        public void Create(EstadoHabitacion estadoHabitacion)
        {
            try
            {
                this.context.EstadoHabitacion.Add(estadoHabitacion);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EstadoHabitacion GetEstadoHabitaciones(int IdEstadoHabitacion)
        {
            return this.context.EstadoHabitacion.Find(IdEstadoHabitacion);
        }

        public List<EstadoHabitacion> GetEstadoHabitaciones()
        {
            return this.context.EstadoHabitacion.ToList();
        }


        public void Remove(EstadoHabitacion estadoHabitacion)
        {
            try
            {
                EstadoHabitacion estadoRemove = this.GetEstadoHabitaciones(estadoHabitacion.IdEstadoHabitacion);
                this.context.EstadoHabitacion.Remove(estadoRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(EstadoHabitacion estadoHabitacion)
        {
            try
            {
                EstadoHabitacion estadoUpdate = this.GetEstadoHabitaciones(estadoHabitacion.IdEstadoHabitacion);

                estadoUpdate.IdEstadoHabitacion = estadoHabitacion.IdEstadoHabitacion;
                estadoUpdate.Descripcion = estadoHabitacion.Descripcion;
                estadoUpdate.Estado = estadoHabitacion.Estado;
                estadoUpdate.FechaCreacion = estadoHabitacion.FechaCreacion;

                this.context.EstadoHabitacion.Update(estadoUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
