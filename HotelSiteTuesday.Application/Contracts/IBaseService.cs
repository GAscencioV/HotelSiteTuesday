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
    public interface IBaseService <TDtoAdd, TDtoUpdate, TdtoRemove, TModel>
    {
        ServiceResult<List<TModel>> GetAll();
        ServiceResult<TModel> Get(int Id);
        ServiceResult<TModel> Save(TDtoAdd habitacionAddDto);
        ServiceResult<TModel> Update(TDtoUpdate habitacionUpdate);
        ServiceResult<TModel> Remove(TdtoRemove habitacionRemoveDto);
    }
}
