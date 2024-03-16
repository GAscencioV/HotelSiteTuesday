using HotelSiteTuesday.Api.DTO.RolUsuario;

namespace HotelSiteTuesday.Api.Models
{
    public class RolUsuarioGetModel : RolUsuarioAddDto
    {
        public int IdRolUsuario { get; set; }
        public string? Descripcion { get; set; }

    }
}
