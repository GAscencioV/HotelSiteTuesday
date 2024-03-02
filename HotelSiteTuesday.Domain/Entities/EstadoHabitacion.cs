using HotelSiteTuesday.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Domain.Entities
{
    internal class EstadoHabitacion : BaseEntity
    {
        public int IdEstadoHabitacion { get; set; }
        public string? Descripcion { get; set; }
    }
}

