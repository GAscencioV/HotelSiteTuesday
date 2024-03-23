using HotelSiteTuesday.Application.Core;
using HotelSiteTuesday.Application.Dtos.Habitacion;
using HotelSiteTuesday.Application.Models.Habitacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Application.Contracts
{
    public interface IHabitacionService : IBaseService<HabitacionAddDto, HabitacionUpdateDto, HabitacionRemoveDto, HabitacionGetModel>
    {
        ServiceResult<List<HabitacionGetModel>> GetHabitacionByEstadoHabitacion(int IdEstadoHabitacion);
        ServiceResult<List<HabitacionGetModel>> GetHabitacionByPiso(int IdPiso);
        ServiceResult<List<HabitacionGetModel>> GetHabitacionByCategoria(int IdCategoria);
    }
}
