using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Context;
using HotelSiteTuesday.Infraestructure.Core;
using HotelSiteTuesday.Infraestructure.Exceptions;
using HotelSiteTuesday.Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Repositories
{
    public class RolUsuarioRepository : BaseRepository<RolUsuario>, IRolUsuarioRepository
    {
        private readonly HotelContext context;
        private readonly ILogger<RolUsuario> logger;

        public RolUsuarioRepository(HotelContext context, ILogger<RolUsuario> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<RolUsuario> GetEntities()
        {
            return base.GetEntities().Where(rol => !rol.Estado).ToList();
        }
        public override void Save(RolUsuario entity)
        {
            try
            {
                if (context.RolUsuario.Any(rol => rol.Descripcion == entity.Descripcion))
                    throw new Exception("Este Rol de Usuario ya existe");

                this.context.RolUsuario.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error Guardando el Rol de Usuario.", ex.ToString());
            }
        }

        public override void Update(RolUsuario entity)
        {
            try
            {
                RolUsuario RolToUpdate = GetEntity(entity.idRolUsuario);

                RolToUpdate.Descripcion = entity.Descripcion;

                this.context.RolUsuario.Update(RolToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error Actualizando el Rol.", ex.ToString());
            }
        }

        public override void Remove(RolUsuario entity)
        {

            try
            {
                RolUsuario RolToRemove = GetEntity(entity.idRolUsuario);

                if (RolToRemove is null)
                    throw new RolUsuarioException("El Rol de Usuario No Existe");

                RolToRemove.Estado = true;

                this.context.RolUsuario.Update(RolToRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error Eliminando el Rol de Usuario.", ex.ToString());
            }

        }

    }
}
