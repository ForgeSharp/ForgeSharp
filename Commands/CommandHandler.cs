using ForgeSharp.Fragments;

namespace ForgeSharp.Commands {
    public class CommandHandler : FragmentManager<GenericCommand> {

        public bool Run(string name, Context context)
        {
            if (!this.IsRegistered(name))
            {
                return false;
            }

            GenericCommand command = this.fragments[name];

            if (!command.MayRun(context))
            {
                return false;
            }

            command.Run(context);

            return true;
        }

        public bool RunIgnoringConditions(string name, Context context)
        {
            if (this.IsRegistered(name)) {
                this.fragments[name].Run(context);

                return true;
            }

            return false;
        }
    }
}