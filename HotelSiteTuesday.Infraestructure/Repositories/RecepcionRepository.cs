using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Domain.Repository;
using HotelSiteTuesday.Infraestructure.Context;
using HotelSiteTuesday.Infraestructure.Core;
using HotelSiteTuesday.Infraestructure.Exceptions;
using HotelSiteTuesday.Infraestructure.Extentions;
using HotelSiteTuesday.Infraestructure.Interfaces;
using HotelSiteTuesday.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelSiteTuesday.Infraestructure.Repositories
{
    public class RecepcionRepository : BaseRepository<Recepcion>, IRecepcionRepository
    {
        private readonly HotelContext context;
        private readonly ILogger<RecepcionRepository> logger;

        public RecepcionRepository(HotelContext context, ILogger<RecepcionRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<Recepcion> GetEntities()
        {
            return base.GetEntities();
        }

        public override void Update (Recepcion entity)
        {
            try
            {
                var recepcionToUpdate = this.GetEntity(entity.IdRecepcion);

                recepcionToUpdate.FechaEntrada = entity.FechaEntrada;
                recepcionToUpdate.FechaSalida = entity.FechaSalida;
                context.Recepcion.Add(entity);
                context.SaveChanges();

                this.context.Recepcion.Update(recepcionToUpdate);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actulizando la Recepcion", ex.ToString());
            } 
        }

        public override void Save(Recepcion entity)
        {
            try
            {
                if (context.Recepcion.Any(ca => ca.IdRecepcion == entity.IdRecepcion))
                    throw new RecepcionException("El Id ya esta registrado");

                this.context.Recepcion.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error creando la categoria", ex.ToString());
            }
        }

        public List<RecepcionModel> GetRecepcionByCliente(int idCliente)
        {
           
          
        }

        public List<RecepcionModel> GetRecepcionByHabitacion(int idHabitacion)
        {
            throw new NotImplementedException();
        }
    }
  }
