using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForgeSharp.Commands {
    public class CommandHandler {
        private readonly Dictionary<string, Type> commands;

        public CommandHandler()
        {
            this.commands = new Dictionary<string, Type>();
        }

        // TODO: Verify type is typeof(Command)?
        public CommandHandler RegisterCommand(Type command)
        {
            CommandName commandNameAttribute = command.GetCustomAttributes(typeof(CommandName), true).FirstOrDefault() as CommandName;

            if (commandNameAttribute != null)
            {
                this.commands.Add(commandNameAttribute.Name, command);
            }
            else {
                throw new Exception($"Command class '{command.Name}' is missing required CommandName attribute");
            }

            return this;
        }

        public CommandHandler RegisterCommands(params Type[] commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                this.RegisterCommand(commands[i]);
            }

            return this;
        }

        public Type GetCommandType(string name)
        {
            return this.commands.GetValueOrDefault(name, null);
        }

        public bool Run(string name, Context context)
        {
            if (!this.IsRegistered(name))
            {
                return false;
            }

            Command instance = this.CreateCommandInstance(name);

            if (!instance.MayRun(context))
            {
                return false;
            }

            instance.Run(context);

            return true;
        }

        public bool RunIgnoringConditions(string name, Context context)
        {
            if (this.IsRegistered(name)) {
                this.CreateCommandInstance(name).Run(context);

                return true;
            }

            return false;
        }

        public bool IsRegistered(string name)
        {
            return this.commands.ContainsKey(name);
        }

        private Command CreateCommandInstance(string name)
        {
            return this.ActivateCommandInstance(this.GetCommandType(name));
        }

        private Command ActivateCommandInstance(Type commandType)
        {
            return (Command)Activator.CreateInstance(commandType);
        }
    }
}