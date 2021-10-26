using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CleanArchitectureController : ControllerBase
    {
        private readonly ILogger<CleanArchitectureController> _logger;

        public CleanArchitectureController(ILogger<CleanArchitectureController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Welcome controller!
        /// </summary>
        /// <returns>A<see cref="string"/> with a welcome message</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public OkObjectResult Get()
        {
            return Ok($"Welcome to the Clean Architecture Template");
        }
    }
}
