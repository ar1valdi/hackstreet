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

        public async Task<Measure[]> GetAllMeasures()
        {
            return await _context.Set<Measure>().ToArrayAsync();
        }

        public async Task<Sensor[]> GetAllSensors()
        {
            return await _context.Set<Sensor>().ToArrayAsync();
        }

        public async Task<Station[]> GetAllStations()
        {
            return await _context.Set<Station>().ToArrayAsync();
        }
    }
}
