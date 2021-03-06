﻿using System;
using Microsoft.Extensions.Logging;

namespace AutofacLab
{
    public class Application
    {
        // NOTE(mickvangelderen): This implementation is Logging framework implementation(serilog/log4net/...) agnostic
        private readonly ILogger<Application> _logger;
        private readonly Handler _handler;

        public Application(ILogger<Application> logger, Handler handler)
        {
            _logger = logger;
            _handler = handler;
        }

        public void Run()
        {
            using (_logger.BeginScope(nameof(Run)))
            {
                _logger.LogInformation("Started at {date}", DateTime.Now);
                _handler.Handle("some event");
            }
        }
    }
}
