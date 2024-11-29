using HackstreeetServer.src.Models;
using HackstreeetServer.src.Services;
using MediatR;

namespace HackstreeetServer.src.Handlers.GetWeatherHandler
{
    public class GetEcoDetails : IRequest<EcoDetails> {
        public float Lat { get; set; }
        public float Lon { get; set; }
    }

    public class GetEcoDetailsHandler
        : IRequestHandler<GetEcoDetails, EcoDetails>
    {
        private IEcoGraderService _service;

        public GetEcoDetailsHandler(IEcoGraderService service)
        {
            _service = service;
        }

        public async Task<EcoDetails> Handle(GetEcoDetails request, CancellationToken cancellationToken)
        {
            var random = new Random();
            var details = new EcoDetails
            {
                Latitude = request.Lat,
                Longitude = request.Lon,
                AirScore = await _service.FilterGrade(request.Lat, request.Lon, "powietrze"),
                SoundScore = await _service.FilterGrade(request.Lat, request.Lon, "hałas"),
                LightScore = await _service.FilterGrade(request.Lat, request.Lon, "światło"),
                WaterScore = await _service.FilterGrade(request.Lat, request.Lon, "woda"),
            };
            details.CalculateOverallScore();
            return details;
        }
    }
}
