using HackstreeetServer.src.Handlers.GetWeatherHandler;
using HackstreeetServer.src.Models;
using HackstreeetServer.src.Services;
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
        private readonly IEcoGraderService ecoGraderService;

        public EcoDetailsController(
            ILogger<EcoDetailsController> logger,
            IEcoGraderService service,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
            ecoGraderService = service;
        }

        [HttpGet]
        [Route("{lat}/{lon}")]
        public Task<EcoDetails> Get(float lat, float lon)
        {
            return _mediator.Send(new GetEcoDetails { Lat = lat, Lon = lon});
        }

        [HttpGet]
        [Route("map/{startLat}/{startLon}/{endLat}/{endLon}/{deltaLat}/{deltaLon}")]
        public Task<EcoDetails[]> GetGetAllDetails(float startLat, float startLon, float endLat, float endLon, float deltaLat, float deltaLon)
        {
            return ecoGraderService.GetAllDetails(startLat, startLon, endLat, endLon, deltaLat, deltaLon);
        }
    }
}
