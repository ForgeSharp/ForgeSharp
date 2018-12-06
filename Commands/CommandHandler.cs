using ForgeSharp.Fragments;
using System.Threading.Tasks;

namespace ForgeSharp.Commands {
    public class CommandHandler : FragmentManager<GenericCommand> {

        public bool Run(string name, Context context)
        {
            if (!this.IsRegistered(name))
            {
                return false;
            }

            GenericCommand command = this.fragments[name];

            // TODO: MayRun should run async?
            if (!command.MayRun(context))
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
            if (this.IsRegistered(name)) {
                this.RunAsync(this.fragments[name], context);

                return true;
            }

            return false;
        }
    }
}