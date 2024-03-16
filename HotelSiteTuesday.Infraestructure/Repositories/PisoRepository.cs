using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Context;
using HotelSiteTuesday.Infraestructure.Core;
using HotelSiteTuesday.Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Repositories
{
    public class PisoRepository : BaseRepository<Piso>, IPisoRepository

    {
        public PisoRepository (HotelContext context) : base(context)
        {

        }
        public override List<Piso> GetEntities()
        {
            return base.GetEntities().Where(ca => !ca.Estado).ToList();
        }
        public override void Update(Piso entity)
        {
            try
            {
                var PisoToUpdate = this.GetEntity(entity.IdPiso);

                if (PisoToUpdate is null)
                    throw new PisoException("El piso no existe.");

                PisoToUpdate.IdPiso = entity.IdPiso;
                PisoToUpdate.Descripcion = entity.Descripcion;
                PisoToUpdate.Estado = entity.Estado;
                PisoToUpdate.FechaCreacion = entity.FechaCreacion;

                this.context.Piso.Update(PisoToUpdate);
                this.context.SaveChanges();

            }

            catch (Exception ex)
            {
                this.logger.LogError ("Error actualizando el piso", ex.ToString());
            }
        }
        public override void Remove(Piso entity)
        {
            try
            {
                Piso PisoToRemove = this.GetEntity(entity.IdPiso);

                if (PisoToRemove is null)
                    throw new PisoException("No se encuentra la categoria.");

                else
                {
                    PisoToRemove.IdPiso = entity.IdPiso;

                    this.context.Piso.Remove(PisoToRemove);
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar el piso", ex.ToString());
            }
        }

        public override void Save(Piso entity)
        {
            try
            {
                if (context.Piso.Any(ca => ca.Descripcion == entity.Descripcion))
                    throw new PisoException("El Piso se encuentra registrada.");

                this.context.Habitacion.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error creando el piso", ex.ToString());
            }
        }

        //Check the query in order to make sure that everything is OK
        public List<PisoModels> GetPisoByEstadoPiso(int IdEstadoPiso)
        {
            List<PisoModels> habitacion = new List<PisoModels>();

            try
            {
                Piso = (from ha in this.context.Piso
                              join eha in this.context.EstadoPiso on ha.IdEstadoPiso equals eha.IdEstadoPiso
                              where ha.IdEstadoPiso == IdEstadoPiso
                        select new PisoModels()
                              {
                                  IdEstadoPiso = eha.IdEstadoPiso,
                                  Descripcion = eha.Descripcion,
                                  Estado = ha.Estado,
                                  IdPiso = ha.IdPiso,
                                  FechaCreacion = ha.FechaCreacion,

                              }).ToList();

                return Piso;
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo los estado de el piso", ex.ToString());
            }

            return Piso;
        }

        
    }
}
