using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Interfaces;
using HotelSiteTuesday.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace HotelSiteTuesday.Infraestructure.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly HotelContext _context;

        public ClientesRepository(HotelContext context)
        {
            _context = context;
        }
        public void create(Clientes clientes)
        {
            try
            {
                _context.Clientes.Add(clientes);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Clientes getClientesById(int IdCliente)
        {
            try
            {
                return _context.Clientes.Find(IdCliente);

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Clientes> GetClientes()
        {
            try
            {
                return _context.Clientes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void remove(Clientes clientes)
        {
            try
            {
                Clientes clientesToRemove = getClientesById(clientes.IdCliente);
                _context.Clientes.Remove(clientesToRemove);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void update(Clientes clientes)
        {
            try
            {
                Clientes clienteToUpdate = getClientesById(clientes.IdCliente);

                clienteToUpdate.IdCliente = clientes.IdCliente;
                clienteToUpdate.NombreCompleto = clientes.NombreCompleto;
                clienteToUpdate.Documento = clientes.Documento;
                clienteToUpdate.Correo = clientes.Correo;

                _context.Clientes.Update(clienteToUpdate);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
    
}
