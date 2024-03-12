using HotelSiteTuesday.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Interfaces
{
    public interface IClientesRepository
    {
        void create(Clientes cliente);
        void remove(Clientes cliente);
        void update(Clientes cliente);

        List<Clientes> GetClientes();
        Clientes getClientesById(int IdCliente);


    }
} 