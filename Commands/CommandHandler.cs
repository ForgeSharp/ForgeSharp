using System;
using System.Collections.Generic;
using System.Linq;
using DNet.Core;
using DNet.Structures;

namespace DNet.Commands {
    public class CommandHandler {
        private readonly Dictionary<string, Type> commands;

        public CommandHandler()
        {
            this.commands = new Dictionary<string, Type>();
        }

        public CommandHandler RegisterCommand(Type command)
        {
            var commandNameAttribute = command.GetCustomAttributes(typeof(CommandName), true).FirstOrDefault() as CommandName;

            if (commandNameAttribute != null)
            {
                this.commands.Add(commandNameAttribute.Name, command);
            }
            else {
                throw new Exception($"Command class '{command.Name}' is missing required CommandName attribute");
            }

            return this;
        }

        public Type GetCommandType(string name)
        {
            return this.commands.GetValueOrDefault(name, null);
        }

        public bool RunIgnoringConditions(string name, Context context)
        {
            if (this.IsRegistered(name)) {
                this.CreateCommandInstance(this.GetCommandType(name)).Run(context);

                return true;
            }

            return false;
        }

        public bool IsRegistered(string name)
        {
            return this.commands.ContainsKey(name);
        }

        private Command CreateCommandInstance(Type commandType)
        {
            return (Command)Activator.CreateInstance(commandType);
        }
    }
}