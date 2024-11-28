using HackstreeetServer.src.Handlers.GetWeatherHandler;
using HackstreeetServer.src.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HackstreeetServer.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EcoDetailsController : ControllerBase
    {

        private readonly ILogger<EcoDetailsController> _logger;
        private readonly IMediator _mediator;

        public EcoDetailsController(
            ILogger<EcoDetailsController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/{lat}/{lon}")]
        public Task<EcoDetails> Get(float lat, float lon)
        {
            return _mediator.Send(new GetEcoDetails { Lat = lat, Lon = lon});
        }
    }
}
