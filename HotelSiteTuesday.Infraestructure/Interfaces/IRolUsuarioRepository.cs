using HotelSiteTuesday.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Interfaces
{
    public interface IRolUsuarioRepository
    {
        void create(RolUsuario rolUsuario);
        void update(RolUsuario rolUsuario);
        void remove(RolUsuario rolUsuario);

        List<RolUsuario> GetRolUsuarios();

        RolUsuario GetRolUsuarioById(int IdRolUsuario);

    }
}
