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
    public class HabitacionRepository : IHabitacionRepository
    {
        private readonly HotelContext context;

        public HabitacionRepository(HotelContext context) 
        {
            this.context = context;
        }

        public void Create(Habitacion habitacion)
        {
            try
            {
                this.context.Habitacion.Add(habitacion);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Habitacion GetHabitacion(int IdHabitacion)
        {
            return this.context.Habitacion.Find(IdHabitacion);
        }

        public List<Habitacion> GetHabitaciones()
        {
            return this.context.Habitacion.ToList();
        }

        public void Remove(Habitacion habitacion)
        {
            try
            {
                Habitacion habitacionRemove = this.GetHabitacion(habitacion.IdHabitacion);
                this.context.Habitacion.Remove(habitacionRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Habitacion habitacion)
        {
            try
            {
                Habitacion habitacionUpdate = this.GetHabitacion(habitacion.IdHabitacion);

                habitacionUpdate.IdHabitacion = habitacion.IdHabitacion;
                habitacionUpdate.Numero = habitacion.Numero;
                habitacionUpdate.Detalle = habitacion.Detalle;
                habitacionUpdate.Precio = habitacion.Precio;
                habitacionUpdate.IdEstadoHabitacion = habitacion.IdEstadoHabitacion;
                habitacionUpdate.IdPiso = habitacion.IdPiso;
                habitacionUpdate.IdCategoria = habitacion.IdCategoria;
                habitacionUpdate.Estado = habitacion.Estado;
                habitacionUpdate.FechaCreacion = habitacion.FechaCreacion;

                this.context.Habitacion.Update(habitacionUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
