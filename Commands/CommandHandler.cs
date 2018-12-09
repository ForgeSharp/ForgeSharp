using DNet.Structures;
using ForgeSharp.Core;
using ForgeSharp.Fragments;
using System.Threading.Tasks;

namespace ForgeSharp.Commands
{
    public class CommandHandler : FragmentManager<GenericCommand>
    {
        protected readonly Bot bot;

        public CommandHandler(Bot bot)
        {
            this.bot = bot;
        }

        public ExecutionResult Run(string name, Context context)
        {
            if (!this.IsRegistered(name))
            {
                return ExecutionResult.NotRegistered;
            }

            GenericCommand command = this.fragments[name];

            if (!this.bot.Authenticator.Authenticate(command, context)) {
                return ExecutionResult.NotAuthorized;
            }
            // TODO: MayRun should run async?
            else if (!command.MayRun(context))
            {
                return ExecutionResult.CommandRefusedToRun;
            }

            this.RunAsync(command, context);

            return ExecutionResult.OK;
        }

        protected void RunAsync(GenericCommand command, Context context)
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