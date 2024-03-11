namespace HotelSiteTuesday.Api.Models
{
    public class HabitacionAddModel
    {
        public int IdHabitacion { get; set; }
        public string? Numero { get; set; }
        public string? Detalle { get; set; }
        public decimal? Precio { get; set; }
    }
}
