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
        public HotelContext( DbContextOptions<HotelContext> options ) : base (options) 
        { 
        
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RolUsuario> RolUsuarios { get; set; }
    }
}
