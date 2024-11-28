using HackstreeetServer.src.Models.Measures;
using HackstreeetServer.src.Repositories;
using MediatR;

namespace HackstreeetServer.src.Handlers.Measures
{
    public class GetAllStations() : IRequest<Station[]>
    {

    }

    public class GetAllStationsHandler
    : IRequestHandler<GetAllStations, Station[]>
    {
        private IMeasureRepository _repository;

        public GetAllStationsHandler(IMeasureRepository repo)
        {
            _repository = repo;
        }

        public Task<Station[]> Handle(GetAllStations request, CancellationToken cancellationToken)
        {
            return _repository.GetAllStations();
        }
    }
}
