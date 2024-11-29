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

        public async Task<Suggestion[]> GetAllSuggetsions()
        {
            var arr = await _context.Set<Suggestion>().ToArrayAsync();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Upvotes = GetVotesCount(arr[i].Id, 'u');
                arr[i].Downvotes = GetVotesCount(arr[i].Id, 'd');
            }
            return arr;
        }

        private int GetVotesCount(Guid id, char val)
        {
            return _context.Set<Vote>().Where(v => v.SuggestionId == id && v.Value == val).Count();
        }

        public async Task<Suggestion?> GetSuggestionById(Guid id)
        {
            var v = await _context.Set<Suggestion>().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (v == null)
            {
                return v;
            }
            v.Upvotes = GetVotesCount(v.Id, 'u');
            v.Downvotes = GetVotesCount(v.Id, 'd');
            return v;
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

        public void AddVote(Vote vote)
        {
            vote.Id = Guid.NewGuid();
            _context.Set<Vote>().Add(vote);
            _context.SaveChanges();
        }

        public void RemoveVote(Guid id)
        {
            var entity = _context.Set<Vote>().Where(x => x.Id == id).FirstOrDefault();

            if (entity == null)
            {
                throw new ArgumentException("Id does not exist");
            }

            _context.Set<Vote>().Remove(entity);
            _context.SaveChanges();
        }

        public Task<Vote?> GetVoteByEmailAndSuggestion(string email, 
            Guid suggestionId)
        {
            return _context.Set<Vote>()
                .Where(x => x.Email == email && x.SuggestionId == suggestionId)
                .FirstOrDefaultAsync();
        }
    }
}
