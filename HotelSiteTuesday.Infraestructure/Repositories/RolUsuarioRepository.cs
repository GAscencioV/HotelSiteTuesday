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
    public class RolUsuarioRepository : IRolUsuarioRepository
    {
        private readonly HotelContext _context;

        public RolUsuarioRepository(HotelContext context) 
        {
            _context = context;
        }
        public void create(RolUsuario rolUsuario)
        {
            try
            {
                _context.RolUsuarios.Add(rolUsuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public RolUsuario GetRolUsuarioById(int IdRolUsuario)
        {
            try
            {
                return _context.RolUsuarios.Find(IdRolUsuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<RolUsuario> GetRolUsuarios()
        {
            try
            {
                return _context.RolUsuarios.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void remove(RolUsuario rolUsuario)
        {
            try
            {
                RolUsuario rolUsuarioToRemove = GetRolUsuarioById(rolUsuario.idRolUsuario);
                _context.RolUsuarios.Remove(rolUsuarioToRemove);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void update(RolUsuario rolUsuario)
        {
            try
            {
                RolUsuario rolUsuarioToUpdate = GetRolUsuarioById(rolUsuario.idRolUsuario);

                rolUsuarioToUpdate.Descipcion = rolUsuario.Descipcion;

                _context.RolUsuarios.Update(rolUsuarioToUpdate);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
