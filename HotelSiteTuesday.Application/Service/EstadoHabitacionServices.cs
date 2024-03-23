using HotelSiteTuesday.Application.Contracts;
using HotelSiteTuesday.Application.Core;
using HotelSiteTuesday.Application.Dtos.Enums;
using HotelSiteTuesday.Application.Dtos.EstadoHabitacion;
using HotelSiteTuesday.Application.Dtos.Habitacion;
using HotelSiteTuesday.Application.Exceptions;
using HotelSiteTuesday.Application.Models.EstadoHabitacion;
using HotelSiteTuesday.Application.Models.Habitacion;
using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Interfaces;
using HotelSiteTuesday.Infraestructure.Repositories;

namespace HotelSiteTuesday.Application.Service
{
    public class EstadoHabitacionServices : IEstadoHabitacionService
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

        public ServiceResult<EstadoHabitacionGetModel> Get(int Id)
        {
            var result = new ServiceResult<EstadoHabitacionGetModel>();

            try
            {
                var estadoHabitacion = estadoHabitacionRepository.GetEntity(Id);

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

        public ServiceResult<List<EstadoHabitacionGetModel>> GetAll()
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
        
        public ServiceResult<EstadoHabitacionGetModel> Save(EstadoHabitacionAddDto estadoHabitacionAddDto)
        {
            var result = new ServiceResult<EstadoHabitacionGetModel>();

            try
            {
                var resultIsValid = this.IsValid(estadoHabitacionAddDto, DtoAction.Save);

                if (!resultIsValid.Success)
                {
                    result.Message = resultIsValid.Message;
                    return result;
                }

                var nuevoEstadoHabitacion = new Domain.Entities.EstadoHabitacion
                {
                    IdEstadoHabitacion = estadoHabitacionAddDto.IdEstadoHabitacion,
                    Descripcion = estadoHabitacionAddDto.Descripcion
                };

                estadoHabitacionRepository.Save(nuevoEstadoHabitacion);
                result.Message = "Estado de Habitación guardado correctamente.";

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

        public ServiceResult<EstadoHabitacionGetModel> Update(EstadoHabitacionUpdateDto estadoHabitacionUpdate)
        {
            var result = new ServiceResult<EstadoHabitacionGetModel>();

            try
            {
                var resultIsValid = this.IsValid(estadoHabitacionUpdate, DtoAction.Update);

                if (!resultIsValid.Success)
                {
                    result.Message = resultIsValid.Message;
                    return result;
                }

                var estadoHabitacion = new EstadoHabitacion
                {
                    Descripcion = estadoHabitacionUpdate.Descripcion,
                };

                estadoHabitacionRepository.Update(estadoHabitacion);
                result.Message = "Estado de Habitación actualizado correctamente.";

            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el estado de la habitación.";
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }

        public ServiceResult<EstadoHabitacionGetModel> Remove(EstadoHabitacionRemoveDto estadoHabitacionRemove)
        {
            var result = new ServiceResult<EstadoHabitacionGetModel>();

            try
            {
                var estadoHabitacion = new EstadoHabitacion
                {
                    IdEstadoHabitacion = estadoHabitacionRemove.IdEstadoHabitacion,
                };

                estadoHabitacionRepository.Remove(estadoHabitacion);
                result.Message = "Estado de Habitación eliminado correctamente.";
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar el estado de la habitacion.";
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }

        private ServiceResult<string> IsValid(EstadoHabitacionDtoBase estadoHabitacionDtoBase, DtoAction action)
        {
            ServiceResult<string> result = new ServiceResult<string>();

            if (string.IsNullOrEmpty(estadoHabitacionDtoBase.Descripcion))
            {
                result.Success = false;
                result.Message = "La descripcion de la habitacion es requerida.";
                return result;
            }

            if (estadoHabitacionDtoBase.Descripcion.Length > 50)
            {
                result.Success = false;
                result.Message = "La descripcion debe tener máximo 50 caracteres.";
                return result;
            }

            if (estadoHabitacionRepository.Exists(ca => ca.IdEstadoHabitacion == estadoHabitacionDtoBase.IdEstadoHabitacion))
            {
                result.Success = false;
                result.Message = $"El estado de la habitacion {estadoHabitacionDtoBase.IdEstadoHabitacion} ya existe.";
                return result;
            }

            return result;
        }

    }
}
