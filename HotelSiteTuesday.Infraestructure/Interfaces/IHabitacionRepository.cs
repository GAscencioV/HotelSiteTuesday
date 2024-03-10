using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Domain.Repository;
using HotelSiteTuesday.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Interfaces
{
    public interface IHabitacionRepository : IBaseRepository<Habitacion>
    {
        List<HabitacionModels> GetHabitacionByEstadoHabitacion (int IdEstadoHabitacion);
        List<HabitacionModels> GetHabitacionByPiso(int IdPiso);
        List<HabitacionModels> GetHabitacionByCategoria(int IdCategoria);


    }
}
