using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PROJECT_NAME.Domain;
using PROJECT_NAME.Domain.Interfaces;
using System.Threading.Tasks;
using PROJECT_NAME.Domain.Entities;

namespace PROJECT_NAME.WebApi.Controllers
{
    /// <summary>
    /// Sample controller for Clean Architecture
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CleanArchitectureController : ControllerBase
    {
        private readonly IStatusService _statusService;
        private readonly ILogger<CleanArchitectureController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="statusService"></param>
        public CleanArchitectureController(ILogger<CleanArchitectureController> logger, IStatusService statusService)
        {
            _logger = logger;
            _statusService = statusService;
        }

        /// <summary>
        /// Sample HTTP GET.  
        /// </summary>
        /// <returns>The service <see cref="Status"/></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Status>> Get()
        {
            _logger.LogInformation("Calling Get Status");

            return Ok(await _statusService.GetStatusAsync());
        }
    }
}
