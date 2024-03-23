using HotelSiteTuesday.Application.Contracts;
using HotelSiteTuesday.Application.Core;
using HotelSiteTuesday.Application.Dtos;
using HotelSiteTuesday.Application.Dtos.Enums;
using HotelSiteTuesday.Application.Dtos.EstadoHabitacion;
using HotelSiteTuesday.Application.Dtos.Habitacion;
using HotelSiteTuesday.Application.Exceptions;
using HotelSiteTuesday.Application.Models.Habitacion;
using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Interfaces;
using HotelSiteTuesday.Infraestructure.Models.Habitacion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HotelSiteTuesday.Application.Service
{
    public class HabitacionServices : IHabitacionService
    {
        private readonly IHabitacionRepository habitacionRepository;
        private readonly ILoggerBase logger;
        private readonly Action<string> errorMethod;
        private readonly IConfiguration configuration;

        public HabitacionServices(ILoggerBase logger, 
                                  IHabitacionRepository habitacionRepository,
                                  IConfiguration configuration)
        { 
            this.logger = logger;
            errorMethod = logger.LogError;
            this.habitacionRepository = habitacionRepository;
            this.configuration = configuration;
        }

        public ServiceResult<HabitacionGetModel> Get(int Id)
        {
            var result = new ServiceResult<HabitacionGetModel>();

            try
            {
                var habitacion = habitacionRepository.GetEntity(Id);

                if (habitacion == null)
                {
                    result.Success = false;
                    result.Message = ("Error obteniendo las habitaciones.");
                }

                else
                {
                    result.Data = new HabitacionGetModel
                    {
                        IdHabitacion = habitacion.IdHabitacion,
                        Numero = habitacion.Numero,
                        Detalle = habitacion.Detalle,
                        Precio = habitacion.Precio,
                        IdEstadoHabitacion = habitacion.IdEstadoHabitacion,
                        IdPiso = habitacion.IdPiso,
                        IdCategoria = habitacion.IdCategoria
                    };
                }
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ("Error obteniendo las habitaciones.");
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }

        public ServiceResult<List<HabitacionGetModel>> GetAll()
        {
            var result = new ServiceResult<List<HabitacionGetModel>>();

            try
            {
                result.Data = habitacionRepository.GetEntities()
                    .Select(cd => new HabitacionGetModel()
                    {
                        IdHabitacion = cd.IdHabitacion,
                        Numero = cd.Numero,
                        Detalle = cd.Detalle,
                        Precio = cd.Precio,
                        IdEstadoHabitacion = cd.IdEstadoHabitacion,
                        IdPiso = cd.IdPiso,
                        IdCategoria = cd.IdCategoria,

                    }).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ("Error obteniendo las habitaciones.");
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }

        public ServiceResult<HabitacionGetModel> Save(HabitacionAddDto habitacionAddDto)
        {
            var result = new ServiceResult<HabitacionGetModel>();

            try
            {
                var resultIsValid = this.IsValid(habitacionAddDto, DtoAction.Save);

                if (!resultIsValid.Success)
                {
                    result.Message = resultIsValid.Message;
                    return result;
                }

                var nuevaHabitacion = new Domain.Entities.Habitacion
                {
                    Numero = habitacionAddDto.Numero,
                    Detalle = habitacionAddDto.Detalle,
                    Precio = habitacionAddDto.Precio,
                };

                habitacionRepository.Save(nuevaHabitacion);
                result.Message = "Habitación guardada correctamente.";
            }

            catch (HabitacionException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                errorMethod(result.Message + ex.ToString());
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ("Error obteniendo las habitaciones.");
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }

        public ServiceResult<HabitacionGetModel> Update(HabitacionUpdateDto habitacionUpdate)
        {
            var result = new ServiceResult<HabitacionGetModel>();

            try
            {
                var resultIsValid = this.IsValid(habitacionUpdate, DtoAction.Update);

                if (!resultIsValid.Success)
                {
                    result.Message = resultIsValid.Message;
                    return result;
                }

                var habitacion = new Habitacion
                {
                    IdHabitacion = habitacionUpdate.IdHabitacion,
                    Numero = habitacionUpdate.Numero,
                    Detalle = habitacionUpdate.Detalle,
                    Precio = habitacionUpdate.Precio,
                };

                habitacionRepository.Update(habitacion);
                result.Message = "Habitación actualizada correctamente.";
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ("Error al actualizar la habitación.");
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }

        public ServiceResult<HabitacionGetModel> Remove(HabitacionRemoveDto habitacionRemoveDto)
        {
            var result = new ServiceResult<HabitacionGetModel>();

            try
            {
                var habitacion = new Habitacion
                {
                    IdHabitacion = habitacionRemoveDto.IdHabitacion,
                };

                habitacionRepository.Remove(habitacion);
                result.Message = "Habitación eliminada correctamente.";
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar la habitación.";
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }

        private ServiceResult<string> IsValid(HabitacionDtoBase habitacionDtoBase, DtoAction action)
        { 
            ServiceResult<string> result = new ServiceResult<string>();

            if (string.IsNullOrEmpty(habitacionDtoBase.Numero))
            {
                result.Success = false;
                result.Message = "El numero de la habitacion es requerido.";
                return result;
            }

            if (habitacionDtoBase.Numero.Length > 50)
            {
                result.Success = false;
                result.Message = "El número de la habitación debe tener máximo 50 caracteres.";
                return result;
            }

            if (string.IsNullOrEmpty(habitacionDtoBase.Detalle))
            {
                result.Success = false; 
                result.Message = "El detalle de la habitación es requerido.";
                return result;
            }

            if (habitacionDtoBase.Detalle.Length > 100)
            {
                result.Success = false;
                result.Message = "El detalle de la habitación debe tener máximo 100 caracteres.";
                return result;
            }

            if (action == DtoAction.Save)
            {
                if (habitacionRepository.Exists(ha => ha.Numero == habitacionDtoBase.Numero))
                {
                    result.Success = false;
                    result.Message = $"La habitación {habitacionDtoBase.Numero} ya existe.";
                    return result;
                }
            }

            return result;
        }

        public ServiceResult<List<HabitacionGetModel>> GetHabitacionByCategoria(int IdCategoria)
        {
            var result = new ServiceResult<List<HabitacionGetModel>>();

            try
            {
                var habitacionesbyCategoria = habitacionRepository.GetHabitacionByCategoria(IdCategoria);

                if (habitacionesbyCategoria == null || !habitacionesbyCategoria.Any())
                {
                    result.Success = false;
                    result.Message = "No se encontraron habitaciones para la categoria de habitación proporcionado.";
                }

                else
                {
                    result.Data = habitacionesbyCategoria.Select(habitacion => new HabitacionGetModel
                    {
                        IdHabitacion = habitacion.IdHabitacion,
                        Numero = habitacion.Numero,
                        Detalle = habitacion.Detalle,
                        Precio = habitacion.Precio,
                        IdEstadoHabitacion = habitacion.IdEstadoHabitacion,
                        IdPiso = habitacion.IdPiso,
                        IdCategoria = habitacion.IdCategoria

                    }).ToList();

                    result.Success = true;
                    result.Message = "Habitaciones obtenidas exitosamente.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las habitaciones";
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }

        public ServiceResult<List<HabitacionGetModel>> GetHabitacionByEstadoHabitacion(int IdEstadoHabitacion)
        {
            var result = new ServiceResult<List<HabitacionGetModel>>();

            try
            {
                var habitacionesbyEstado = habitacionRepository.GetHabitacionByEstadoHabitacion(IdEstadoHabitacion);

                if (habitacionesbyEstado == null || !habitacionesbyEstado.Any())
                {
                    result.Success = false;
                    result.Message = "No se encontraron habitaciones para el estado de habitación proporcionado.";
                }

                else
                {
                    result.Data = habitacionesbyEstado.Select(habitacion => new HabitacionGetModel
                    {
                        IdHabitacion = habitacion.IdHabitacion,
                        Numero = habitacion.Numero,
                        Detalle = habitacion.Detalle,
                        Precio = habitacion.Precio,
                        IdEstadoHabitacion = habitacion.IdEstadoHabitacion,
                        IdPiso = habitacion.IdPiso,
                        IdCategoria = habitacion.IdCategoria

                    }).ToList();

                    result.Success = true;
                    result.Message = "Habitaciones obtenidas exitosamente.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las habitaciones";
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }

        public ServiceResult<List<HabitacionGetModel>> GetHabitacionByPiso(int IdPiso)
        {
            var result = new ServiceResult<List<HabitacionGetModel>>();

            try
            {
                var habitacionesbyPiso = habitacionRepository.GetHabitacionByPiso(IdPiso);

                if (habitacionesbyPiso == null || !habitacionesbyPiso.Any())
                {
                    result.Success = false;
                    result.Message = "No se encontraron habitaciones para el piso de habitación proporcionado.";
                }

                else
                {
                    result.Data = habitacionesbyPiso.Select(habitacion => new HabitacionGetModel
                    {
                        IdHabitacion = habitacion.IdHabitacion,
                        Numero = habitacion.Numero,
                        Detalle = habitacion.Detalle,
                        Precio = habitacion.Precio,
                        IdEstadoHabitacion = habitacion.IdEstadoHabitacion,
                        IdPiso = habitacion.IdPiso,
                        IdCategoria = habitacion.IdCategoria

                    }).ToList();

                    result.Success = true;
                    result.Message = "Habitaciones obtenidas exitosamente.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las habitaciones";
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }
    }
}