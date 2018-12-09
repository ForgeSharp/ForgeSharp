using ForgeSharp.Constraints;
using ForgeSharp.Commands;
using ForgeSharp.Fragments;
using ForgeSharp.Core;

namespace ForgeSharp.Premade.Commands
{
    [Authorize(AuthLevel.BotOwner)]
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
