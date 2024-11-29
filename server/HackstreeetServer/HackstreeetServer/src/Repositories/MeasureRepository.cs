using HackstreeetServer.src.DatabaseContext;
using HackstreeetServer.src.Models.Measures;
using Microsoft.EntityFrameworkCore;

namespace HackstreeetServer.src.Repositories
{
    public class MeasureRepository : IMeasureRepository
    {
        private GreenLifeDbContext _context;
        
        public MeasureRepository() {
            _context = new GreenLifeDbContext();
        }

        public Task<Measure[]> GetAllMeasures()
        {
            return _context.Set<Measure>().ToArrayAsync();
        }

        public Task<Station[]> GetAllStations()
        {
            return _context.Set<Station>().ToArrayAsync();
        }
        public Task<Station[]> GetAllStationsWithMeasures()
        {
            return _context.Set<Station>().Include(s => s.Measures).ToArrayAsync();
        }

        public Task<Measure[]> GetMeasureBySensing(string sensing)
        {
            return _context.Set<Measure>().Where(s => s.Sensing == sensing).ToArrayAsync();
        }

        public Task<Station[]> GetStationBySensing(string sensing)
        {
            return _context.Set<Station>().Include(am => am.Measures).Where(s => s.Measures.Where(m => m.Sensing == sensing).Any()).ToArrayAsync();
        }
        public Task<Measure[]> GetMeasureBySensingAndStationID(string sensing,long stationID)
        {
            return _context.Set<Measure>().Where(s => s.Sensing == sensing && s.StationId == stationID).ToArrayAsync();
        }
    }
}
