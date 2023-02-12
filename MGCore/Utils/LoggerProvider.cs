using Microsoft.Extensions.Logging;
#if FINDAMODERNTHREADSAFEFILTERINGLOGGERWITHCATEGORYFILTERSANDUINADTHREADSAFE
namespace MGCore.Utils
{
    internal class LoggerProvider : ILoggerProvider
    {
        private bool disposedValue;


        private readonly string _categoryName;
        private readonly Func<string, LogLevel, bool> _filter;
        private readonly Action<string, LogLevel, string> _write;

        public LoggerProvider(string cat) => _categoryName=cat;
       
        
       
        static Dictionary< string, ILoggerProvider>  loggerProviders = new Dictionary< string, ILoggerProvider>();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue=true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~LoggerProvider()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }



        /// <summary>
        /// create a logger
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
           
            if ( loggerProviders.TryGetValue( categoryName, out ILoggerProvider provider)) return provider.CreateLogger(categoryName);
            else
                loggerProviders.Add(categoryName, provider);
            return SimpleLogger.CreateLogger(categoryName);
            
      
        }
        }
    }
}

#endif