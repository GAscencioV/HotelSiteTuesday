using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Exeptions
{
    internal class ClientesExceptions : Exception

    {

        public ClientesExceptions(string Message) : base(Message) 
        {
            SaveLog(Message);
        }
        private void SaveLog(string Message)
        { }
    }
}
