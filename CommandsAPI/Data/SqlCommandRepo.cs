using System;
using System.Collections.Generic;
using System.Linq;
using CommandsAPI.Models;

namespace CommandsAPI.Data{

    public class SqlCommandRepo : ICommandRepo
    {
        private readonly CommandContext _context;

        public SqlCommandRepo(CommandContext context)
        {
            _context = context ;
        }

        public void CreateCommand(Command cmd)
        {
            
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));

            _context.Commands.Add(cmd);
            SaveChanges();
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null )
                throw new ArgumentNullException(nameof(cmd));

            _context.Commands.Remove(cmd);
            SaveChanges();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }


        public void UpdateCommand(Command cmd)
        {
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}