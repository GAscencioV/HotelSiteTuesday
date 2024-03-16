namespace HotelSiteTuesday.Api.Dtos
{
    public class DtoBase
    {
        public int IdRecepcion { get; set; }
        public int? IdCliente { get; set; }
        public int? IdHabitacion { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaSalidaConfirmacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public decimal? PrecioInicial { get; set; }
        public decimal? TotalPagado { get; set; }
        public decimal? Adelanto { get; set; }
        public decimal? PrecioRestante { get; set; }
        public decimal? CostoPenalidad { get; set; }
        public string? Observacion { get; set; }
        public new bool? Estado { get; set; }
        public string? Descripcion { get; set; }
        public string? Nombre { get; set; }

    }
}
