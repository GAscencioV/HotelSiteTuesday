using HotelSiteTuesday.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Domain.Entities
{
    public class Piso : BaseEntity
    {
        public int IdPiso { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; } 
        public DateTime FechaCreacion { get; set; }
    }
}
