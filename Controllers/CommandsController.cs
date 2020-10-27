﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Data;
using Commander.Models;
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

        public CommandsController(ICommanderRepo repository)
        {
            _repository = repository;
        }


        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> getAllCommands()
        {
            var commandItems = _repository.GetAppCommands();

            return Ok(commandItems);
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
