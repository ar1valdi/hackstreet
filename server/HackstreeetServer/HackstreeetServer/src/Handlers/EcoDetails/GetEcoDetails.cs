using HackstreeetServer.src.Models;
using HackstreeetServer.src.Repositories;
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
        private IMeasureRepository _measureRepository;

        public GetEcoDetailsHandler(IEcoGraderService service, IMeasureRepository measureRepository)
        {
            _service = service;
            _measureRepository = measureRepository;
        }

        public async Task<EcoDetails> Handle(GetEcoDetails request, CancellationToken cancellationToken)
        {
            var measures = await _measureRepository.GetAllStationsWithMeasures();
            var details = new EcoDetails
            {
                Latitude = request.Lat,
                Longitude = request.Lon,
                AirScore = await _service.FilterGrade(request.Lat, request.Lon, "powietrze", measures),
                SoundScore = await _service.FilterGrade(request.Lat, request.Lon, "hałas", measures),
                LightScore = await _service.FilterGrade(request.Lat, request.Lon, "światło", measures),
                WaterScore = await _service.FilterGrade(request.Lat, request.Lon, "woda", measures),
            };
            details.CalculateOverallScore();
            return details;
        }
    }
}
