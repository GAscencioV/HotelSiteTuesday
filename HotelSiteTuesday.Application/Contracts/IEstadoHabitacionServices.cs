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
        ServiceResult<List<EstadoHabitacionGetModel>> GetEstadosHabitaciones();
        ServiceResult<EstadoHabitacionGetModel> GetEstadosHabitacionesbyId(int IdEstadoHabitacion);
        ServiceResult<EstadoHabitacionGetModel> SaveEstadoHabitacion(EstadoHabitacionAddDto estadoHabitacionDto);
        ServiceResult<EstadoHabitacionGetModel> UpdateEstadoHabitacion(EstadoHabitacionUpdateDto estadoHabitacionDto);
        ServiceResult<EstadoHabitacionGetModel> RemoveEstadoHabitacion(EstadoHabitacionRemoveDto estadoHabitacionDto);
    }
}