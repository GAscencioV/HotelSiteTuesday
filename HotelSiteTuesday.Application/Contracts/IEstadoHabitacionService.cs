using HotelSiteTuesday.Application.Dtos.EstadoHabitacion;
using HotelSiteTuesday.Application.Models.EstadoHabitacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Application.Contracts
{
    public interface IEstadoHabitacionService : IBaseService<EstadoHabitacionAddDto,EstadoHabitacionUpdateDto,EstadoHabitacionRemoveDto, EstadoHabitacionGetModel>
    {
        //There's no special method for Estado de Habitacion.
    }
}
