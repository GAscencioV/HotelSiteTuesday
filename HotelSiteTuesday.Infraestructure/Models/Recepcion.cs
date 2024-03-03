using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Models
{
    public class Recepcion
    {
        public int idRecepcion { get; set; }

        public string Descripcion { get; set; }

        public DateOnly Fecha { get; set; }

        public string Nombre { get; set; }


    }
}
