using HotelSiteTuesday.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Domain.Entities
{
    public class Clientes : BaseEntity
    {
        public int IdCliente { get; set; }
        public string TipoDocumento  { get; set; }
        public string Documento { get; set; }
        public string  NombreCompleto { get; set; }
        public string Correo  { get; set; }
        public  Boolean Estado { get; set; }
        public DateTime FechaCreacion { get; set; }



    }
}
