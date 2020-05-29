using Autofac;
using Serilog;
using Microsoft.Extensions.Logging;
using Serilog.Formatting.Compact;

namespace AutofacLab
{
    class Program
    {
        private static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<LoggerFactory>().As<ILoggerFactory>().SingleInstance();
            builder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>)).SingleInstance();
            builder.RegisterType<Application>();
            builder.RegisterType<Handler>();

            var container = builder.Build();
            var loggerFactory = container.Resolve<ILoggerFactory>();
            // NOTE(mickvangelderen): Here we could swap out Serilog with a different logging library.
            // However, I am afraid Microsoft.Extensions.Logging hides some of serilog's functionality
            // because it needs to be generic. It may also make things more complicated.
            loggerFactory.AddSerilog(DefaultLoggerConfiguration().CreateLogger(), true);

            using (var scope = container.BeginLifetimeScope())
            {
                var application = scope.Resolve<Application>();
                application.Run();
            }
        }

        private static LoggerConfiguration DefaultLoggerConfiguration() =>
            new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(new CompactJsonFormatter());
    }
}
