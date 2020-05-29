using System;
using Microsoft.Extensions.Logging;

namespace AutofacLab
{
    public class Handler
    {
        private readonly ILogger<Handler> _logger;

        public Handler(ILogger<Handler> logger)
        {
            _logger = logger;
        }

        public void Handle(string someEvent)
        {
            using (_logger.BeginScope(nameof(Handle)))
            {
                _logger.LogInformation("Handled event {event}", someEvent);
            }
        }
    }
}
