using ForgeSharp.Commands;
using ForgeSharp.Core;

namespace ForgeSharp.Premade.Commands
{
    public class Stop : PremadeCommand
    {
        public override string Name => "stop";

        public override string Description => "Stop the application";

        public override string Version => "1.0.0";

        // TODO
        public override void Run(Context context)
        {
            context.Reply("Stopping the application ...");
            context.Bot.Shutdown();
        }
    }
}
