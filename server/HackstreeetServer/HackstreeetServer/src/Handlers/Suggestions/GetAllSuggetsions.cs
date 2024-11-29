using HackstreeetServer.src.Models.Suggestions;
using HackstreeetServer.src.Repositories;
using HackstreeetServer.src.Repositories.Interfaces;
using MediatR;

namespace HackstreeetServer.src.Handlers.Suggestions
{
    public class GetAllSuggestions : IRequest<Suggestion[]>
    {
    }

    public class GetAllSuggestionsHandler
        : IRequestHandler<GetAllSuggestions, Suggestion[]>
    {
        private ISuggestionRepository _repo;

        public GetAllSuggestionsHandler(ISuggestionRepository r)
        {
            _repo = r;
        }

        public Task<Suggestion[]> Handle(GetAllSuggestions request, CancellationToken cancellationToken)
        {
            return _repo.GetAllSuggetsions();
        }
    }
}
