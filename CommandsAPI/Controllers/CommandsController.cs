
using System.Collections.Generic;
using AutoMapper;
using CommandsAPI.Data;
using CommandsAPI.Dtos;
using CommandsAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CommandsAPI.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _commandRepo;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo commandRepo, IMapper mapper)
        {
            _commandRepo = commandRepo;
            _mapper = mapper;
        }


        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAppCommands()
        {
            var items = _commandRepo.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(items));

        }


        //GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var item = _commandRepo.GetCommandById(id);

            if(item == null)
                return NotFound();
            return Ok(_mapper.Map<CommandReadDto>(item));
            
        }

        //POST api/commands
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var command = _mapper.Map<Command>(commandCreateDto);
            _commandRepo.CreateCommand(command);

            var commandReadDto = _mapper.Map<CommandReadDto>(command);
            return CreatedAtRoute(nameof(GetCommandById), new {Id= commandReadDto.Id}, commandReadDto);

        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand (int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelRepo = _commandRepo.GetCommandById(id);
            if(commandModelRepo == null)
                return NotFound();

            _mapper.Map(commandUpdateDto, commandModelRepo);

            _commandRepo.UpdateCommand(commandModelRepo);

            return NoContent();

        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelRepo = _commandRepo.GetCommandById(id);
            if(commandModelRepo == null)
                return NotFound();

            var commandPatch = _mapper.Map<CommandUpdateDto>(commandModelRepo);
            patchDoc.ApplyTo(commandPatch, ModelState);

            if(!TryValidateModel(commandPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(commandPatch, commandModelRepo);
            _commandRepo.UpdateCommand(commandModelRepo);

            return NoContent();
        }

        //Delete api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommandById(int id)
        {
            var command = _commandRepo.GetCommandById(id);

            if (command == null)
                return NotFound();

            _commandRepo.DeleteCommand(command);
            return NoContent();
        }
    }
}