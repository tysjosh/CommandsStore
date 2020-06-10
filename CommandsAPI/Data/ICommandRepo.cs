using System.Collections.Generic;
using CommandsAPI.Models;

namespace CommandsAPI.Data{

    public interface ICommandRepo
    
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);

        void CreateCommand(Command cmd);

        void UpdateCommand(Command cmd);

        void DeleteCommand(Command cmd);

    }
}