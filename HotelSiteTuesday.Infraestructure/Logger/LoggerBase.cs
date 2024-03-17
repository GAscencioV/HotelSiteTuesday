using HotelSiteTuesday.Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Logger
{
    //I can't use abstract class because an abstract class can't be directly instantiated.
    public class LoggerBase : ILoggerBase
    {
        private readonly ILogger<LoggerBase> logger; 

        public LoggerBase(ILogger<LoggerBase> logger)
        {
            this.logger = logger;
        }

        public void LogError(string message)
        {
            logger.LogError(message);
        }
    }
}
