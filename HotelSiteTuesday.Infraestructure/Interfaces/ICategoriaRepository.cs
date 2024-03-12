using HotelSiteTuesday.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Interfaces
{
    public interface ICategoriaRepository
    {

        void create(Categoria categoria);

        void update(Categoria categoria);
        void remove (Categoria categoria);

        List<Categoria> GetCategoria();
        Categoria GetCategoriaById(int Id);


    }
}