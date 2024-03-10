using HotelSiteTuesday.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Domain.Entities
{
    [Table("RolUsuario")]
    public class RolUsuario : BaseEntity
    {
        [Key]
        [Column("IdRolUsuario")]
        public int idRolUsuario { get; set; }
        public string? Descripcion { get; set; }
    }
}
