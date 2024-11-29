using HackstreeetServer.src.Models;

namespace HackstreeetServer.src.Services
{
    public interface IEcoGraderService
    {
        public Task<float> FilterGrade(float latitude, float longitude, string categoryFilter);
        public Task<EcoDetails[]> GetAllDetails(float startLat, float startLon, float endLat, float endLon, float deltaLat, float deltaLon);
    }
}
