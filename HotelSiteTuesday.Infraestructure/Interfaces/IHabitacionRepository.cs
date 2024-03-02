using HotelSiteTuesday.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Interfaces
{
    public interface IHabitacionRepository
    {
        void Create(Habitacion habitacion);
        void Update(Habitacion habitacion);
        void Remove(Habitacion habitacion);
        List<Habitacion> GetHabitaciones();

        Habitacion GetHabitacion(int IdHabitacion);

    }
}
