using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Context;
using HotelSiteTuesday.Infraestructure.Core;
using HotelSiteTuesday.Infraestructure.Interfaces;
using HotelSiteTuesday.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly HotelContext context;
        private readonly ILogger<UsuarioRepository> logger;

        public UsuarioRepository(HotelContext context, ILogger<UsuarioRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<Usuario> GetEntities()
        {
            return base.GetEntities().Where(us => !us.Estado).ToList();
        }

        public override void Update(Usuario entity)
        {
            try
            {
                Usuario usuarioToUpdate = GetEntity(entity.IdUsuario);

                usuarioToUpdate.IdRolUsuario = entity.IdRolUsuario;
                usuarioToUpdate.NombreCompleto = entity.NombreCompleto;
                usuarioToUpdate.Clave = entity.Clave;
                usuarioToUpdate.Correo = entity.Correo;

                this.context.Usuario.Update(usuarioToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error Actualizando el usuario.", ex.ToString());
            }
        }
        public override void Remove(Usuario entity)
        {
            Usuario usuarioToRemove = GetEntity(entity.IdUsuario);

            usuarioToRemove.Estado = true;

            this.context.Usuario.Update(usuarioToRemove);
            this.context.SaveChanges();
        }

        public override void Save(Usuario entity)
        {
            try
            {
                if (context.Usuario.Any(us => us.Correo == entity.Correo))
                    throw new Exception("Este correo ya existe");

                this.context.Usuario.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error Guardando el usuario.", ex.ToString());
            }
        }
        public List<UsuarioModel> GetUsuarioByRolUsuario(int idRolUsuario)
        {
            List<UsuarioModel> usuarios = new List<UsuarioModel>();
            try
            {
                var query = (from usu in this.context.Usuario
                             join rol in this.context.RolUsuario on usu.IdRolUsuario equals rol.idRolUsuario
                             where usu.IdRolUsuario == idRolUsuario
                             select new UsuarioModel() 
                             {
                                 IdRolUsuario = rol.idRolUsuario,
                                 descripcionRol = rol.Descripcion,
                                 IdUsuario = usu.IdUsuario,
                                 Clave = usu.Clave,
                                 Correo = usu.Correo,
                                 NombreCompleto = usu.NombreCompleto
                             }).ToList();
                return usuarios;
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error Obtener usuarios por ID el usuario.", ex.ToString());
            }

            return usuarios;
        }
    }
}
