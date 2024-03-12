using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Interfaces
{
    public interface ICategoriaRepository
    {

        void create(ICategoriaRepository categoriaRepository);
        void update(ICategoriaRepository categoriaRepository);
        void remove(ICategoriaRepository categoriaRepository);


        List<ICategoriaRepository> GetCategoriaRepositories();
        ICategoriaRepository GetCategoriaRepositoryById(int Id);
    }
}