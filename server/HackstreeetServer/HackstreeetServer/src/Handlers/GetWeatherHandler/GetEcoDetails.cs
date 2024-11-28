using HackstreeetServer.src.Models;
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

        public Task<EcoDetails> Handle(GetEcoDetails request, CancellationToken cancellationToken)
        {
            var random = new Random();
            var details = new EcoDetails
            {
                Latitude = request.Lat,
                Longitude = request.Lon,
                AirScore = (float)random.NextDouble() * 10,
                SoundScore = (float)random.NextDouble() * 10
            };
            details.CalculateOverallScore();
            return Task.FromResult(details);
        }
    }
}
