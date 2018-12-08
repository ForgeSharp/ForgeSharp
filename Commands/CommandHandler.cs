using DNet.Structures;
using ForgeSharp.Attributes;
using ForgeSharp.Core;
using ForgeSharp.Fragments;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ForgeSharp.Commands
{
    public sealed class CommandHandler : FragmentManager<GenericCommand>
    {
        private readonly Bot bot;

        public CommandHandler(Bot bot)
        {
            this.bot = bot;
        }

        public bool Run(string name, Context context)
        {
            if (!this.IsRegistered(name))
            {
                return false;
            }

            GenericCommand command = this.fragments[name];

            if (!this.bot.Authenticator.Authenticate(command, context)) {
                return false;
            }
            // TODO: MayRun should run async?
            else if (!command.MayRun(context))
            {
                return false;
            }

            this.RunAsync(command, context);

            return true;
        }

        private void RunAsync(GenericCommand command, Context context)
        {
            Task.Run(() => command.Run(context));
        }

        public bool RunIgnoringConditions(string name, Context context)
        {
            if (this.IsRegistered(name))
            {
                this.RunAsync(this.fragments[name], context);

                return true;
            }

            return false;
        }

        public AuthLevel DetermineAuthLevel(User user)
        {
            if (this.bot.Options.OwnerId == user.Id)
            {
                return AuthLevel.BotOwner;
            }

            return AuthLevel.Default;
        }
    }
}