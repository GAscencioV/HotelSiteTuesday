
namespace HotelSiteTuesday.Domain.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity() 
        {
            this.Estado = false;
            this.FechaCreacion = DateTime.Now;
        }
        public bool Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

    }
}
