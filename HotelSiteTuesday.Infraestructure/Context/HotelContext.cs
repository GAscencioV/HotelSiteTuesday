using HotelSiteTuesday.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base (options) 
        {

        }

        #region "DbSets"
        public DbSet<Habitacion> Habitacion { get; set; }
        public DbSet<EstadoHabitacion> EstadoHabitacion { get; set; }
        public DbSet<Piso> Piso { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        #endregion
    }
}