using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Interfaces
{
    public interface IClientesRepository
    {
        void create(IClientesRepository clientesRepository);
        void update(IClientesRepository clientesRepository);
        void remove(IClientesRepository clientesRepository);

        List<IClientesRepository> GetClientesRepositories();
        IClientesRepository GetClientesRepositoryById(int IdCliente);
    }
} 