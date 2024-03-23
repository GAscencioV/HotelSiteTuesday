using HotelSiteTuesday.Application.Core;
using HotelSiteTuesday.Application.Dtos.EstadoHabitacion;
using HotelSiteTuesday.Application.Exceptions;
using HotelSiteTuesday.Application.Models.EstadoHabitacion;
using HotelSiteTuesday.Application.Models.Habitacion;
using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Interfaces;

namespace HotelSiteTuesday.Application.Service
{
    public class EstadoHabitacionServices : IEstadoHabitacionServices
    {
        private readonly IEstadoHabitacionRepository estadoHabitacionRepository;
        private readonly ILoggerBase logger;
        private readonly Action<string> errorMethod;

        public EstadoHabitacionServices(ILoggerBase logger,
                                        IEstadoHabitacionRepository estadoHabitacionRepository)
        {
            this.logger = logger;
            errorMethod = logger.LogError;
            this.estadoHabitacionRepository = estadoHabitacionRepository;
        }

        public ServiceResult<List<EstadoHabitacionGetModel>> GetEstadosHabitaciones()
        {
            var result = new ServiceResult<List<EstadoHabitacionGetModel>>();

            try
            {
                result.Data = estadoHabitacionRepository.GetEntities()
                    .Select(cd => new EstadoHabitacionGetModel()
                    { 
                        IdEstadoHabitacion = cd.IdEstadoHabitacion,
                        Descripcion = cd.Descripcion,

                    }).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los estados de habitacion";
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }

        public ServiceResult<EstadoHabitacionGetModel> GetEstadosHabitacionesbyId(int IdEstadoHabitacion)
        {
            var result = new ServiceResult<EstadoHabitacionGetModel>();

            try
            {
               var estadoHabitacion = estadoHabitacionRepository.GetEntity(IdEstadoHabitacion);

                if (estadoHabitacion == null)
                {
                    result.Success = false;
                    result.Message = "No existe un estado de habitacion con ese ID.";
                }

                else
                {
                    result.Data = new EstadoHabitacionGetModel
                    {
                        IdEstadoHabitacion = estadoHabitacion.IdEstadoHabitacion,
                        Descripcion = estadoHabitacion.Descripcion,
                    };
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los estados de habitacion.";
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }

        //Method to validate when you save a room state
        private void ValidarEstadoHabitacion(EstadoHabitacionAddDto estadoHabitacionDto)
        {
            if (string.IsNullOrEmpty(estadoHabitacionDto.Descripcion))
            {
                throw new EstadoHabitacionException("La descripcion de la habitacion es requerida.");
            }

            if (estadoHabitacionDto.Descripcion.Length > 50)
            {
                throw new EstadoHabitacionException("La descripcion debe tener máximo 50 caracteres.");
            }
        }

        public ServiceResult<EstadoHabitacionGetModel> SaveEstadoHabitacion(EstadoHabitacionAddDto estadoHabitacionDto)
        {
            var result = new ServiceResult<EstadoHabitacionGetModel>();

            try
            {
                ValidarEstadoHabitacion(estadoHabitacionDto);

                var nuevoEstadoHabitacion = new Domain.Entities.EstadoHabitacion
                {
                    IdEstadoHabitacion = estadoHabitacionDto.IdEstadoHabitacion,
                    Descripcion = estadoHabitacionDto.Descripcion
                };

                estadoHabitacionRepository.Save(nuevoEstadoHabitacion);

            }

            catch (EstadoHabitacionException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                errorMethod(result.Message + ex.ToString());
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los estados de habitacion";
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }

        public ServiceResult<EstadoHabitacionGetModel> UpdateEstadoHabitacion(EstadoHabitacionUpdateDto estadoHabitacionDto)
        {
            var result = new ServiceResult<EstadoHabitacionGetModel>();

            try
            {
                if (this.estadoHabitacionRepository.Exists(ca => ca.IdEstadoHabitacion == estadoHabitacionDto.IdEstadoHabitacion))
                {
                    result.Success = false;
                    result.Message = $"El estado de la habitacion {estadoHabitacionDto.IdEstadoHabitacion} ya existe.";
                    return result;
                }

                var estadoHabitacion = new EstadoHabitacion
                {
                    Descripcion = estadoHabitacionDto.Descripcion,
                };

                estadoHabitacionRepository.Update(estadoHabitacion);
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el estado de la habitación.";
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }

        public ServiceResult<EstadoHabitacionGetModel> RemoveEstadoHabitacion(EstadoHabitacionRemoveDto estadoHabitacionDto)
        {
            var result = new ServiceResult<EstadoHabitacionGetModel>();

            try
            {
                if (this.estadoHabitacionRepository.Exists(ca => ca.IdEstadoHabitacion == estadoHabitacionDto.IdEstadoHabitacion))
                {
                    result.Success = false;
                    result.Message = $"El estado de la habitacion con el ID{estadoHabitacionDto.IdEstadoHabitacion} no existe.";
                    return result;
                }

                var estadoHabitacion = new EstadoHabitacion
                {
                    IdEstadoHabitacion = estadoHabitacionDto.IdEstadoHabitacion,
                };

                estadoHabitacionRepository.Remove(estadoHabitacion);
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar el estado de la habitacion.";
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }

    }
}
