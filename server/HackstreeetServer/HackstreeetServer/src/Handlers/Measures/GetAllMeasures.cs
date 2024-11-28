using HackstreeetServer.src.Models;
using HackstreeetServer.src.Models.Measures;
using HackstreeetServer.src.Repositories;
using MediatR;

namespace HackstreeetServer.src.Handlers.Measures
{
    public class GetAllMeasures : IRequest<Measure[]>
    {}

    public class GetAllMeasuresHandler
        : IRequestHandler<GetAllMeasures, Measure[]>
    {
        private IMeasureRepository _repository;

        public GetAllMeasuresHandler(IMeasureRepository repo)
        {
            _repository = repo;
        }

        public Task<Measure[]> Handle(GetAllMeasures request, CancellationToken cancellationToken)
        {
            return _repository.GetAllMeasures();
        }
    }
}
