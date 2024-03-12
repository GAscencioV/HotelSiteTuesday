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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly HotelContext _context;

        public CategoriaRepository(HotelContext context)
        {
            _context = context;
        }
        public void create(Categoria categoria)
        {
            try
            {
                _context.Categoria.Add(categoria);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Categoria GetCategoriaById(int Id)
        {
            try
            {
                return _context.Categoria.Find(Id);

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Categoria> GetCategoria()
        {
            try
            {
                return _context.Categoria.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void remove(Categoria categoria)
        {
            try
            {
                Categoria categoriaToRemove = GetCategoriaById(categoria.Id);
                _context.Categoria.Remove(categoriaToRemove);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void update(Categoria categoria)
        {
            try
            {
                Categoria categoriaToUpdate = GetCategoriaById(categoria.Id);

                categoriaToUpdate.Id = categoria.Id;
                categoriaToUpdate.Descripcion= categoria.Descripcion;
 

                _context.Categoria.Update(categoriaToUpdate);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }

}