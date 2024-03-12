using Microsoft.EntityFrameworkCore;
using HotelSiteTuesday.Domain.Entities;

namespace HotelSiteTuesday.Infraestructure.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        { }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Clientes> Clientes { get; set; }



    }
}