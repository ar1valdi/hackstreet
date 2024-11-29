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
        [Route("map/{dLat}/{dLon}/{str}")]
        public Task<EcoDetailMapField[]> GetGetAllDetails(float dLat, float dLon, string str)
        {
            float startLat = 54.30f;
            float startLon = 18.48f;
            float endLat = 54.43f;
            float endLon = 18.82f;
            return ecoGraderService.GetAllDetails(startLat, startLon, endLat, endLon, dLat, dLon, [str]);
        }
    }
}


public class req
{
    public string[] categoryFilter { get; set; }
    public float dLat { get; set; }
    public float dLon { get; set; }
}