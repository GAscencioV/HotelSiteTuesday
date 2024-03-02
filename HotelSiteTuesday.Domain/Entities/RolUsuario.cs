using HotelSiteTuesday.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Domain.Entities
{
    public class RolUsuario : BaseEntity
    {
        public int idRolUsuario { get; set; }
        public string? Descipcion { get; set; }
    }
}
