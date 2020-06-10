using System.Collections.Generic;
using CommandsAPI.Models;

namespace CommandsAPI.Data{

    public class MockCommandRepo : ICommandRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id=0, HowTo="Boil an egg", Line="Boil Coffee", Platform="Kettle & Pan"},
                new Command{Id=1, HowTo="Cut bread", Line="Get a Knife", Platform="Knife & Chooping board"}

            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0, HowTo="Have a goal", Line="Boil Coffee", Platform="Kettle & Pan"};
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}