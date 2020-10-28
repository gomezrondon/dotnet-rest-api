using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Data;
using Commander.Models;
using Commander.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{

    //api/commands
    // [Route("api[controller]")] 
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMediator _mediator;
        

        public CommandsController(ICommanderRepo repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }


        //GET api/commands
        [HttpGet]
        public ActionResult GetAllCommands()
        {
            var query = new GetAllCommandsQuery();
            var result =  _mediator.Send(query);
            return Ok(result);
        }

        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(String id)
        {
            var command = _repository.GetCommandById(id);

            return Ok(command);
        }


        [HttpPost]
        public ActionResult CreateCommand([FromBody] Command command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            if (command.Line == string.Empty)
            {
                ModelState.AddModelError("line", "no debe estar vacio");
            }

            _repository.InsertCommand(command);

            return Ok(command);
        }

    }
}
