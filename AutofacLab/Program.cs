using Autofac;
using Serilog;
using Microsoft.Extensions.Logging;
using Serilog.Formatting.Compact;

namespace AutofacLab
{
    class Program
    {
        private static LoggerConfiguration DefaultLoggerConfiguration() =>
            new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(new CompactJsonFormatter());

        private static void Main()
        {
            var loggerFactory = new LoggerFactory().AddSerilog(DefaultLoggerConfiguration().CreateLogger(), true);
            var application = new Application(loggerFactory);

            application.Run();
        }
    }
}
