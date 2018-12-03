using ForgeSharp.Commands;
using ForgeSharp.Core;

namespace ForgeSharp.Premade.Commands
{
    public class Stop : PremadeCommand
    {
        public override string Name => "stop";

        public override string Description => "Stop the application";

        // TODO
        public override async void Run(Context context)
        {
            await context.Reply("Stopping the application ...");
            context.Bot.Shutdown();
        }
    }
}
