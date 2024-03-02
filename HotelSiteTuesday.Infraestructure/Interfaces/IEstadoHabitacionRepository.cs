using HotelSiteTuesday.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Interfaces
{
    public interface IEstadoHabitacionRepository
    {
        void Create(EstadoHabitacion estadoHabitacion);
        void Update(EstadoHabitacion estadoHabitacion);
        void Remove(EstadoHabitacion estadoHabitacion);
        List<EstadoHabitacion> GetEstadoHabitaciones();

        Habitacion GetEstadoHabitaciones(int IdHabitacion);
    }
}
