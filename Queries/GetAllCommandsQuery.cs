using System.Collections.Generic;
using Commander.Models;
using MediatR;

namespace Commander.Queries
{
    public class GetAllCommandsQuery: IRequest<List<Command>>
    {
        
    }
}