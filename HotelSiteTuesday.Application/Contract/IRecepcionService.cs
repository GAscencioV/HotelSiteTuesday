using HotelSiteTuesday.Application.Core;
using HotelSiteTuesday.Application.Dtos.Recepcion;
using HotelSiteTuesday.Application.Model.Recepcion;

namespace HotelSiteTuesday.Application.Contract
{
    /// <summary>
    /// Revisar si hay error aqui 
    /// Si da error, puede ser que falte un metodo de ControllerAPI
    /// </summary>
    public interface IRecepcionService
    {
        ServicesResult<List<RecepcionGetModel>> GetRecepcion();
        ServicesResult<RecepcionGetModel> GetRecepcion(int idCliente);
        ServicesResult<RecepcionGetModel> SaveRecepcion(RecepcionDto recepcionDto);
        ServicesResult<RecepcionGetModel> UpdateRecepcion(RecepcionDto recepcionDto);

        ServicesResult<RecepcionGetModel> RemoveRecepcion(int idCliente);


    }
}
