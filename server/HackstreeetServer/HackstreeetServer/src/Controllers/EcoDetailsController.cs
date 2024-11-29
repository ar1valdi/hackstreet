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

        [HttpPost]
        [Route("map")]
        public Task<EcoDetailMapField[]> GetGetAllDetails(string[] categoryFilter, float startLat= 54.30f, float startLon = 18.48f, 
            float endLat=54.43f, float endLon=18.82f, float deltaLat=0.1f, float deltaLon=0.1f)
        {
            return ecoGraderService.GetAllDetails(startLat, startLon, endLat, endLon, deltaLat, deltaLon, categoryFilter);
        }
    }
}
