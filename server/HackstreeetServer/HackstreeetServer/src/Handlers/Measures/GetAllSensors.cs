using HackstreeetServer.src.Models.Measures;
using HackstreeetServer.src.Repositories;
using MediatR;

namespace HackstreeetServer.src.Handlers.Measures
{
    public class GetAllSensors() : IRequest<Sensor[]>
    {

    }

    public class GetAllSensorsHandler
    : IRequestHandler<GetAllSensors, Sensor[]>
    {
        private IMeasureRepository _repository;

        public GetAllSensorsHandler(IMeasureRepository repo)
        {
            _repository = repo;
        }

        public Task<Sensor[]> Handle(GetAllSensors request, CancellationToken cancellationToken)
        {
            return _repository.GetAllSensors();
        }
    }
}
