using HotelSiteTuesday.Application.Core;
using HotelSiteTuesday.Application.Dtos.Habitacion;
using HotelSiteTuesday.Application.Models.Habitacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Application.Service
{
    public interface IHabitacionServices
    {
        ServiceResult<List<HabitacionGetModel>> GetHabitaciones();
        ServiceResult<HabitacionGetModel> SaveHabitacion(HabitacionDto habitacionDto);
        ServiceResult<HabitacionGetModel> UpdateHabitacion(HabitacionDto habitacionDto);
        ServiceResult<HabitacionGetModel> RemoveHabitacion(HabitacionDto habitacionDto);
    }
}