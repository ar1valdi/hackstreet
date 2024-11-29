using HackstreeetServer.src.DatabaseContext;
using HackstreeetServer.src.Models.Suggestions;
using HackstreeetServer.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HackstreeetServer.src.Repositories
{
    public class SuggestionRepository : ISuggestionRepository
    {
        GreenLifeDbContext _context;

        public SuggestionRepository()
        {
            _context = new GreenLifeDbContext();
        }

        public void AddSuggestion(Suggestion newSuggestion)
        {
            newSuggestion.Id = Guid.NewGuid();
            _context.Set<Suggestion>().Add(newSuggestion);
            _context.SaveChanges();
        }

        public Task<Suggestion[]> GetAllSuggetsions()
        {
            return _context.Set<Suggestion>().ToArrayAsync();
        }

        public Task<Suggestion?> GetSuggestionById(Guid id)
        {
            return _context.Set<Suggestion>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void RemoveSuggestion(Guid id)
        {
            var entity = _context.Set<Suggestion>().Where(x => x.Id == id).FirstOrDefault();

            if (entity == null)
            {
                throw new ArgumentException("Id does not exist");
            }

            _context.Set<Suggestion>().Remove(entity);
            _context.SaveChanges();
        }

        public void UpdateSuggestion(Guid id, Suggestion newSuggestion)
        {
            var entity = _context.Set<Suggestion>().Where(x => x.Id == id).FirstOrDefault();

            if (entity == null)
            {
                throw new ArgumentException("Id does not exist");
            }

            entity.Latitude = newSuggestion.Latitude;
            entity.Longitude = newSuggestion.Longitude;
            entity.Description = newSuggestion.Description;
            entity.Downgrades = newSuggestion.Downgrades;
            entity.Duration = newSuggestion.Duration;
            entity.AddedBy = newSuggestion.AddedBy;
            entity.WaterImprovement = newSuggestion.WaterImprovement;
            entity.AirImprovement = newSuggestion.AirImprovement;
            entity.SoundImprovement = newSuggestion.SoundImprovement;
            entity.LightImprovement = newSuggestion.LightImprovement;
            _context.SaveChanges();
        }
    }
}
