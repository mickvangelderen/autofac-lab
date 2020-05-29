using System;
using Microsoft.Extensions.Logging;

namespace AutofacLab
{
    public class Handler
    {
        private readonly ILogger<Handler> _loggerFactory;

        public Handler(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory.CreateLogger<Handler>();
        }

        public void Handle(string someEvent)
        {
            using (_loggerFactory.BeginScope(nameof(Handle)))
            {
                _loggerFactory.LogInformation("Handled event {event}", someEvent);
            }
        }
    }
}
