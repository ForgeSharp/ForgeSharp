using ForgeSharp.Commands;

namespace ForgeSharp.Premade.Commands
{
    public class Ping : Command
    {
        public override string Name => "ping";

        public override string Description => "Displays the bot's latency";

        public override string Author => "CloudRex <cloudrex@outlook.com>";

        public override string Version => "1.0.0";

        // TODO
        public override void Run(Context context)
        {
            context.Reply("Ping?");
        }
    }
}
