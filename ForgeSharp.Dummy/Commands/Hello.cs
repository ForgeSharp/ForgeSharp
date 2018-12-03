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
            context.Reply("Hello world!");
        }
    }
}
