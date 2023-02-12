using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if FINDAMODERNTHREADSAFEFILTERINGLOGGERWITHCATEGORYFILTERSANDUINADTHREADSAFE
namespace MGCore.Utils
{


    internal static class LoggingBuilder:ILoggingBuilder
    {
        public IServiceCollection Services => new ServiceCollection();

        public static void AddProvider(ILoggerProvider provider)
        {
            _providers.Add(provider);
        }
    }
}
#endif