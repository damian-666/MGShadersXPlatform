using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if FINDAMODERNFILTERINGLOGGER
namespace MGCore.Utils
{

    /// <summary>
    /// singleton logger for tracing output
    /// </summary>
    public class SimpleLogger
    {
       
    
         ILogger _logger;
    
        /// <summary>
        /// 
        /// </summary>
        public static ILogger Instance => CreateLogger("General");

        public static ILogger CreateLogger( string cat)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                  .SetMinimumLevel(LogLevel.Information)
                  .AddProvider(new LoggerProvider( cat));
            });
            return loggerFactory.CreateLogger(cat);
        }
    }
}
#endif