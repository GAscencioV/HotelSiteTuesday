using HotelSiteTuesday.Infraestructure.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Interfaces
{
    public interface IRecepcionRepository
    {
        void create(Recepcion recepcion);
        void update(Recepcion recepcion);
        void delete(Recepcion recepcion);

        List <Recepcion> GetRecepcionid();

        Recepcion GetRecepcionid(int idRecepcion);
    }
}
