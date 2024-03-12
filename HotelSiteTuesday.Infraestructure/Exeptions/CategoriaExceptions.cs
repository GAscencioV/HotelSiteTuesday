using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Exeptions
{
        internal class CategoriaExceptions : Exception

        {

            public CategoriaExceptions(string Message) : base(Message)
            {
                SaveLog(Message);
            }
            private void SaveLog(string Message)
            { }
        }
    
}
