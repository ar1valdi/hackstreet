using HackstreeetServer.src.Models.Measures;

namespace HackstreeetServer.src.Repositories
{
    public interface IMeasureRepository
    {
        public Task<Measure[]> GetAllMeasures();
        public Task<Station[]> GetAllStations();
    }
}
