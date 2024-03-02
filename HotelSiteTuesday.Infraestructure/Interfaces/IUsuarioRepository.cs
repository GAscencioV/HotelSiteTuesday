using HotelSiteTuesday.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Interfaces
{
    public interface IUsuarioRepository
    {
        void create(Usuario Usuario);
        void update(Usuario Usuario);
        void remove(Usuario Usuario);

        List<Usuario> GetUsuarios();

        Usuario GetUsuarioById(int IdUsuario);
    }
}
