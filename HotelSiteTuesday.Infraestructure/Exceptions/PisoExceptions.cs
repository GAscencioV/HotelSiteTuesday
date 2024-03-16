using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Exceptions
{
    public class PisoExceptions : Exception
    {
        public PisoExceptions(string Message) : base(Message)
        {
            SaveLog(Message);
        }
        private void SaveLog(string Message)
        {

        }
    }
}
