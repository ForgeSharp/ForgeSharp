using ForgeSharp.Commands;
using ForgeSharp.Fragments;

namespace ForgeSharp.Premade.Commands
{
    public class Stop : Command
    {
        public override Meta Meta => new Meta {
            Name = "stop",
            Description = "Stop the application"
        };

        // TODO
        public override async void Run(Context context)
        {
            await context.Reply("Stopping the application ...");
            context.Bot.Shutdown();
        }
    }
}
