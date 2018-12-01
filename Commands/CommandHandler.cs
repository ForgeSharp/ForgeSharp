using ForgeSharp.Fragments;

namespace ForgeSharp.Commands {
    public class CommandHandler : FragmentManager<GenericCommand> {

        public bool Run(string name, Context context)
        {
            if (!this.IsRegistered(name))
            {
                return false;
            }

            GenericCommand instance = this.CreateInstance(name);

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
                this.CreateInstance(name).Run(context);

                return true;
            }

            return false;
        }
    }
}