using AutoMapper;
using CommandsAPI.Dtos;
using CommandsAPI.Models;

namespace CommandsAPI.Profiles{

    public class CommandProfile: Profile
    {


        public CommandProfile()
        {
            CreateMap<Command, CommandReadDto>();

            CreateMap<CommandCreateDto, Command>();

            CreateMap<CommandUpdateDto, Command>();

            CreateMap<Command, CommandUpdateDto>();
        }
    } 
}