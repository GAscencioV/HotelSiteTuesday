using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Application.Dtos.EstadoHabitacion
{
    public record EstadoHabitacionDto
    {
        public int IdEstadoHabitacion { get; set; }
        public string? Descripcion { get; set; }
    }
}
