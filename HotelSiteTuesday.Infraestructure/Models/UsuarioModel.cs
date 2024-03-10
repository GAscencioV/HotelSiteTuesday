using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }

        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public int? IdRolUsuario { get; set; }
        public string? descripcionRol { get; set; }
        public string? Clave { get; set; }

    }
}
