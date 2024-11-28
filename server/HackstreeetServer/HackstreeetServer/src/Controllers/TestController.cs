using HackstreeetServer.src.Handlers.GetWeatherHandler;
using HackstreeetServer.src.Handlers.Measures;
using HackstreeetServer.src.Models;
using HackstreeetServer.src.Models.Measures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HackstreeetServer.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        private readonly ILogger<EcoDetailsController> _logger;
        private readonly IMediator _mediator;

        public TestController(
            ILogger<EcoDetailsController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllMeasures")]
        public Task<Measure[]> GetMeasures()
        {
            return _mediator.Send(new GetAllMeasures());
        }


        [HttpGet]
        [Route("getAllStations")]
        public Task<Station[]> GetStations(float lat, float lon)
        {
            return _mediator.Send(new GetAllStations());
        }
    }
}
