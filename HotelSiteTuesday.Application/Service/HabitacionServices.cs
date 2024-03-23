using HotelSiteTuesday.Application.Contracts;
using HotelSiteTuesday.Application.Core;
using HotelSiteTuesday.Application.Dtos;
using HotelSiteTuesday.Application.Dtos.Enums;
using HotelSiteTuesday.Application.Dtos.Habitacion;
using HotelSiteTuesday.Application.Exceptions;
using HotelSiteTuesday.Application.Models.Habitacion;
using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Interfaces;
using HotelSiteTuesday.Infraestructure.Models.Habitacion;
using Microsoft.Extensions.Logging;

namespace HotelSiteTuesday.Application.Service
{
    public class HabitacionServices : IHabitacionService
    {
        private readonly IHabitacionRepository habitacionRepository;
        private readonly ILoggerBase logger;
        private readonly Action<string> errorMethod;

        public HabitacionServices(ILoggerBase logger, 
                                  IHabitacionRepository habitacionRepository)
        { 
            this.logger = logger;
            errorMethod = logger.LogError;
            this.habitacionRepository = habitacionRepository;
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
                    result.Message = "No existe una habitacion con ese ID.";
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
                result.Message = "Error obteniendo la habitación";
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
                result.Message = "Error obteniendo las habitaciones";
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }

        //Method to validate when you save a room
        private void ValidarHabitaciones(HabitacionDtoBase habitacionDto)
        {
            if (string.IsNullOrEmpty(habitacionDto.Numero))
            {
                throw new HabitacionException("El numero de la habitacion es requerido.");
            }

            if (habitacionDto.Numero.Length > 50)
            {
                throw new HabitacionException("El número de la habitación debe tener máximo 50 caracteres.");
            }

            if (string.IsNullOrEmpty(habitacionDto.Detalle))
            {
                throw new HabitacionException("El detalle de la habitación es requerido.");
            }

            if (habitacionDto.Detalle.Length > 100)
            {
                throw new HabitacionException("El detalle de la habitación debe tener máximo 100 caracteres.");
            }

            if (habitacionRepository.Exists(ha => ha.Numero == habitacionDto.Numero))
            {
                throw new HabitacionException($"La habitación {habitacionDto.Numero} ya existe.");
            }

            if (habitacionRepository.Exists(ha => ha.IdHabitacion == habitacionDto.IdHabitacion))
            {
                throw new HabitacionException($"La habitacion {habitacionDto.IdHabitacion} no existe.");
            }
        }
        public ServiceResult<HabitacionGetModel> Save(HabitacionAddDto habitacionAddDto)
        {
            var result = new ServiceResult<HabitacionGetModel>();

            try
            {
                ValidarHabitaciones(habitacionAddDto);

                var nuevaHabitacion = new Domain.Entities.Habitacion
                {
                    Numero = habitacionAddDto.Numero,
                    Detalle = habitacionAddDto.Detalle,
                    Precio = habitacionAddDto.Precio,
                };

                habitacionRepository.Save(nuevaHabitacion);
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
                result.Message = "Error obteniendo las habitaciones";
                errorMethod(result.Message + ex.ToString());
            }

            return result;
        }

        public ServiceResult<HabitacionGetModel> Update(HabitacionUpdateDto habitacionUpdate)
        {
            var result = new ServiceResult<HabitacionGetModel>();

            try
            {
                ValidarHabitaciones(habitacionUpdate);

                var habitacion = new Habitacion
                {
                    IdHabitacion = habitacionUpdate.IdHabitacion,
                    Numero = habitacionUpdate.Numero,
                    Detalle = habitacionUpdate.Detalle,
                    Precio = habitacionUpdate.Precio,
                };

                habitacionRepository.Update(habitacion);
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar la habitación.";
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
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar la habitación.";
                errorMethod(result.Message + ex.ToString());
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