using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Application.Exceptions
{
    public class EstadoHabitacionException : Exception
    {
        public EstadoHabitacionException(string message) : base(message)
        {
            
        }
    }
}
