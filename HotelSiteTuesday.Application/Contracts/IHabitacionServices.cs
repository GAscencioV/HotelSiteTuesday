using HotelSiteTuesday.Application.Core;
using HotelSiteTuesday.Application.Dtos.Habitacion;
using HotelSiteTuesday.Application.Models.Habitacion;

namespace HotelSiteTuesday.Application.Service
{
    public interface IHabitacionServices
    {
        ServiceResult<List<HabitacionGetModel>> GetHabitaciones();
        ServiceResult<HabitacionGetModel> GetHabitacion(int IdHabitacion);
        ServiceResult<HabitacionGetModel> SaveHabitacion(HabitacionAddDto habitacionAddDto);
        ServiceResult<HabitacionGetModel> UpdateHabitacion(HabitacionUpdateDto habitacionUpdate);
        ServiceResult<HabitacionGetModel> RemoveHabitacion(HabitacionRemoveDto habitacionRemoveDto);
        ServiceResult<List<HabitacionGetModel>> GetHabitacionByEstadoHabitacion(int IdEstadoHabitacion);
        ServiceResult<List<HabitacionGetModel>> GetHabitacionByPiso(int IdPiso);
        ServiceResult<List<HabitacionGetModel>> GetHabitacionByCategoria(int IdCategoria);


    }
}