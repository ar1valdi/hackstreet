using HackstreeetServer.src.Models.Suggestions;

namespace HackstreeetServer.src.Repositories.Interfaces
{
    public interface ISuggestionRepository
    {
        public void AddSuggestion(Suggestion newSuggestion);
        public void RemoveSuggestion(Guid id);
        public void UpdateSuggestion(Guid id, Suggestion newSuggestion);
        public Task<Suggestion?> GetSuggestionById(Guid id);
        public Task<Suggestion[]> GetAllSuggetsions();
        public void AddVote(Vote vote);
        public void RemoveVote(Guid id);
        public Task<Vote> GetVoteByEmailAndSuggestion(string email, Guid suggestionId);
    }
}
