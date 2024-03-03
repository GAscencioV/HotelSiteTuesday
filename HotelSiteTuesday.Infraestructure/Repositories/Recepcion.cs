using HotelSiteTuesday.Domain.Entities;
using HotelSiteTuesday.Infraestructure.Context;
using HotelSiteTuesday.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelSiteTuesday.Infraestructure.Repositories
{
    public class RecepcionRepository : IRecepcionRepository
    {
        private readonly HotelContext _context;

        public RecepcionRepository(HotelContext context)
        {
            _context = context;
        }

        public void Create(Recepcion recepcion)
        {
            try
            {
                _context.Recepcion.Add(recepcion);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Recepcion recepcion)
        {
            try
            {
                _context.Recepcion.Update(recepcion);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Recepcion recepcion)
        {
            try
            {
                _context.Recepcion.Remove(recepcion);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Recepcion> GetAllRecepciones()
        {
            try
            {
                return _context.Recepcion.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Recepcion GetRecepcionById(int idRecepcion)
        {
            try
            {
                return _context.Recepcion.Find(idRecepcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
