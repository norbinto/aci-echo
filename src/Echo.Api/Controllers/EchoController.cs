using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Echo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EchoController : ControllerBase
    {
        private readonly ILogger<EchoController> _logger;

        public EchoController(ILogger<EchoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Task<Response> Post(string message, CancellationToken token)
        {
            var from = Environment.GetEnvironmentVariable(Constants.APP_NAME) is null
                ? string.Empty
                : $" from {Environment.GetEnvironmentVariable(Constants.APP_NAME)}";
            return Task.FromResult(new Response
                {
                    Message = $"{message}{from}"
                }
            );
        }
    }
}