using ForgeSharp.Commands;

namespace ForgeSharp.Premade.Commands
{
    public class Stop : Command
    {
        public override string Name => "stop";

        public override string Description => "Stop the application";

        public override string Author => "CloudRex <cloudrex@outlook.com>";

        public override string Version => "1.0.0";

        // TODO
        public override void Run(Context context)
        {
            context.Reply("Stopping the application ...");
            context.Bot.Shutdown();
        }
    }
}
