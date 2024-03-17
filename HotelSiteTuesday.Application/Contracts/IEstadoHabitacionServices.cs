using HotelSiteTuesday.Application.Core;
using HotelSiteTuesday.Application.Dtos.EstadoHabitacion;
using HotelSiteTuesday.Application.Models.EstadoHabitacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Application.Service
{
    public interface IEstadoHabitacionServices
    {
        ServiceResult<List<EstadoHabitacionGetModel>> GetEstadoHabitaciones();
        ServiceResult<EstadoHabitacionGetModel> SaveEstadoHabitacion(EstadoHabitacionDto estadoHabitacionDto);
        ServiceResult<EstadoHabitacionGetModel> UpdateEstadoHabitacion(EstadoHabitacionDto estadoHabitacionDto);
        ServiceResult<EstadoHabitacionGetModel> RemoveEstadoHabitacion(EstadoHabitacionDto estadoHabitacionDto);
    }
}