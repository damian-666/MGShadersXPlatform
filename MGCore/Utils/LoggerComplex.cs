#if FINDAMODERNTHREADSAFEFILTERINGLOGGERWITHCATEGORYFILTERSANDUINADTHREADSAFE

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGCore.Utils
{




    public class
         LoggerProvider : ILoggerProvider
    {
        private bool disposedValue;

        public ILogger CreateLogger(string categoryName)
        {
            return new Logger();
        }
        

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
    }
    public  class LoggerFactory<TState>: ILoggerFactory
    {
        /// <summary>
        /// add a logger provider
        /// </summary>
        /// <param name="provider"></param>
        public void AddProvider(ILoggerProvider provider)
        {
            AddProvider(provider);
           
        }

  
        
        public ILogger CreateLogger(string categoryName)
        {
            return Logger.Instance;
        }

        public void Dispose()
        {
            
        }

        internal object Create(Action<object> value)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// a singleton for ILogger
    /// </summary>
    public class Logger: ILogger, IDisposable
    {
        private bool disposedValue;

        public static ILogger Instance { get; set; } = new Logger();

        public IDisposable BeginScope<TState>(TState state) where TState : notnull
        {

            return new Logger();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log(string message)
        {
            Trace.WriteLine(message);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Trace.WriteLine(logLevel.ToString() + ": " + eventId.ToString() + ": " + formatter(state, exception)+ state.ToString());
        }

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
        // ~Logger()
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
    }
    
    
}
#endif