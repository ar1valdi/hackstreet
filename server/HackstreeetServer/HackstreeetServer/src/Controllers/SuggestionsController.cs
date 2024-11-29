using HackstreeetServer.src.Handlers.Suggestions;
using HackstreeetServer.src.Models;
using HackstreeetServer.src.Models.Suggestions;
using HackstreeetServer.src.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HackstreeetServer.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuggestionsController : Controller
    {
        private readonly ILogger<Suggestion> _logger;
        private readonly IMediator _mediator;
        private readonly ISuggestionRepository _repo;

        public SuggestionsController(
            ILogger<Suggestion> logger,
            IMediator mediator,
            ISuggestionRepository repo)
        {
            _repo = repo;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public Task<Suggestion[]> Get()
        {
            return _mediator.Send(new GetAllSuggestions());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var s = await _repo.GetSuggestionById(id);
            if (s == null) {
                return NotFound();
            }
            return Ok(s);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Suggestion newSuggestion)
        {
            try
            {
                _repo.AddSuggestion(newSuggestion);
            }
            catch (ArgumentException ex)
            {
                return Conflict();
            }
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(Guid id, Suggestion newSuggestion)
        {
            try
            {
                _repo.UpdateSuggestion(id, newSuggestion);
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            try
            {
                _repo.RemoveSuggestion(id);
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        [Route("/upvote")]
        public async Task<IActionResult> Upvote(Guid id, string email)
        {
            return Ok();
        }

        [HttpPost]
        [Route("/downvote")]
        public async Task<IActionResult> Downvote(Guid id, string email)
        {
            return Ok();
        }
    }
}
