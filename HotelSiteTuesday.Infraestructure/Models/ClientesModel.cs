using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Models
{
    public class ClientesModel
    {
        public int IdCliente { get; set; }
        public string Documento { get; set; }
        public string? NombreCompleto { get; set; }

        public string Correo { get; set;}

    }
}
