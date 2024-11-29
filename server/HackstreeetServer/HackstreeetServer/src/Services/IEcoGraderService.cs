using HackstreeetServer.src.Models;
using HackstreeetServer.src.Models.Measures;

namespace HackstreeetServer.src.Services
{
    public interface IEcoGraderService
    {
        public Task<float> FilterGrade(float latitude, float longitude, string categoryFilter, Station[] stations);
        public Task<EcoDetailMapField[]> GetAllDetails(float startLat, float startLon, float endLat, float endLon, float deltaLat, float deltaLon, string[] categoryFilter);
    }
}
