using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Domain.Repository;
using HotelSiteTuesday.Infraestructure.Extentions;
using HotelSiteTuesday.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Interfaces
{
    public interface IRecepcionRepository : IBaseRepository <Recepcion>
    {
       List<RecepcionModel> GetRecepcionByCliente(int idCliente);
       List<RecepcionModel> GetRecepcionByHabitacion(int idHabitacion);

    }
}
