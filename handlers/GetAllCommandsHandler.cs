using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Commander.Data;
using Commander.Models;
using Commander.Queries;
using MediatR;

namespace Commander.handlers
{
    public class GetAllCommandsHandler : IRequestHandler<GetAllCommandsQuery,List<Command> >
    {
        
        private readonly ICommanderRepo _repository;

        public GetAllCommandsHandler(ICommanderRepo repository)
        {
            _repository = repository;
        }

        public async Task<List<Command>> Handle(GetAllCommandsQuery request, CancellationToken cancellationToken)
        {
            var commandItems = await _repository.GetAppCommands();

            return commandItems;
        }
    }
}