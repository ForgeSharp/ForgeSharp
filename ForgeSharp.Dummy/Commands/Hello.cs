using DNet.Structures.Guilds;
using ForgeSharp.Commands;
using ForgeSharp.Core;

namespace ForgeSharp.Dummy.Commands
{
    internal class Hello : PremadeCommand
    {
        public override string Name => "hello";

        public override string Description => "Says hello world";

        public override void Run(Context context)
        {
            Guild g = context.Message.Guild;

            if (g != null)
            {
                context.Reply($"This guild's name is: {g.Name}");
            }
            else
            {
                context.Reply("Could not access guild!");
            }
        }
    }
}
