using System;
using System.Collections.Generic;

namespace PatternsLab2
{
    class CommandManager
    {
        private static CommandManager instance = null;

        public static CommandManager GetInstance()
        {
            if (instance == null)
            {
                instance = new CommandManager();
            }
            return instance;
        }
        public List<ICommand> GetCommands()
        {
            return new List<ICommand>(Commands);
        }

        private List<ICommand> Commands;
        private bool Lock = false;

        private CommandManager()
        {
            Commands = new List<ICommand>();
        }

        public void Registry(ICommand command)
        {
            if (Lock) return;
            Commands.Add(command);
        }
        public void Undo()
        {
            Lock = true;

            Commands.RemoveAt(Commands.Count - 1);
            foreach (ICommand command in Commands)
            {
                command.Ecexute();
            }

            Lock = false;
        }
    }
}