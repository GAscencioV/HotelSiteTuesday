namespace HotelSiteTuesday.Api.Models
{
    public class UsuarioAddModel
    {
        public int usuarioID { get; set; }
        public string? nombreCompleto { get; set; }
        public string? correo { get; set; }
        public string? clave { get; set; }
        public int rolUsuarioId { get; set; }
    }
}
