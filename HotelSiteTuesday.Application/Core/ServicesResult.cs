using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Application.Core
{
    public class ServicesResult <TData>
    {
        public bool Success { get; set; }

        public string? Message { get; set; }

        public TData? Data { get; set; }

    }
}
