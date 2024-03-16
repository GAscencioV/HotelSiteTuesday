
using HotelSiteTuesday.Application.Contract;
using HotelSiteTuesday.Application.Core;
using HotelSiteTuesday.Application.Dtos.Recepcion;
using HotelSiteTuesday.Application.Model.Recepcion;
using HotelSiteTuesday.Infraestructure.Interfaces;
using HotelSiteTuesday.Infraestructure.Repositories;
using Microsoft.Extensions.Logging;

namespace HotelSiteTuesday.Application.Services
{
    public class RecepcionService : IRecepcionService
    {

        private readonly ILogger <RecepcionService> logger;
        private readonly IRecepcionRepository recepcionRepository;

        public RecepcionService(ILogger<RecepcionService> logger, 
                                               IRecepcionRepository recepcionRepository) {

            this.logger = logger;
            this.recepcionRepository = recepcionRepository;
        }

        public ServicesResult<List<RecepcionGetModel>> GetRecepcion()
        {

            ServicesResult<List <RecepcionGetModel>> result = new ServicesResult<List<RecepcionGetModel>>();

            try
            {

            }catch (Exception ex)
            {
                throw;
            }

            result.Data = new List<RecepcionGetModel>();
            return result;
        }

        public ServicesResult<RecepcionGetModel> GetRecepcion(int idCliente)
        {
            throw new NotImplementedException();
        }

        public ServicesResult<RecepcionGetModel> RemoveRecepcion(int idCliente)
        {
            throw new NotImplementedException();
        }

        public ServicesResult<RecepcionGetModel> SaveRecepcion(RecepcionDto recepcionDto)
        {
            throw new NotImplementedException();
        }

        public ServicesResult<RecepcionGetModel> UpdateRecepcion(RecepcionDto recepcionDto)
        {
            throw new NotImplementedException();
        }
    }
}
