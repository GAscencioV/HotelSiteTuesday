namespace HotelSiteTuesday.Api.DTO.Usuario
{
    public class UsuarioDtoBase : BaseDto
    {
        public string? nombreCompleto { get; set; }
        public string? correo { get; set; }
        public string? clave { get; set; }
        public int rolUsuarioId { get; set; }
    }
}
