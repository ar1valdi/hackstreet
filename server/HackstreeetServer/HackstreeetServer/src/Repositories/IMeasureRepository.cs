using HackstreeetServer.src.Models.Measures;

namespace HackstreeetServer.src.Repositories
{
    public interface IMeasureRepository
    {
        public Task<Measure[]> GetAllMeasures();
        public Task<Station[]> GetAllStationsWithMeasures();
        public Task<Station[]> GetAllStations();
        public Task<Measure[]> GetMeasureBySensing(string sensing);
        public Task<Measure[]> GetMeasureBySensingAndStationID(string sensing,long stationID);
        public Task<Station[]> GetStationBySensing(string sensing);
    }
}
