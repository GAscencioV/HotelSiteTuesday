using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion{ get; set; }
        public Boolean Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
