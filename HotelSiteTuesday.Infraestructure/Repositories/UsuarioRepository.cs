using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Context;
using HotelSiteTuesday.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HotelContext _context;

        public UsuarioRepository(HotelContext context) 
        {
            _context = context;
        }
        public void create(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario GetUsuarioById(int idUsuario)
        {
            try
            {
                return _context.Usuarios.Find(idUsuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Usuario> GetUsuarios()
        {
            try
            {
                return _context.Usuarios.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void remove(Usuario usuario)
        {
            try
            {
                Usuario usuarioToRemove = GetUsuarioById(usuario.IdUsuario);
                _context.Usuarios.Remove(usuarioToRemove);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void update(Usuario usuario)
        {
            try
            {
                Usuario usuarioToUpdate = GetUsuarioById(usuario.IdUsuario);

                usuarioToUpdate.IdRolUsuario = usuario.IdRolUsuario;
                usuarioToUpdate.NombreCompleto = usuario.NombreCompleto;
                usuarioToUpdate.Clave = usuario.Clave;
                usuarioToUpdate.Correo = usuario.Correo;

                _context.Usuarios.Update(usuarioToUpdate);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
