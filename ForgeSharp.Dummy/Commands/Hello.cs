using ForgeSharp.Commands;

namespace DummyForgeSharpBot.Commands
{
    public class Hello : GenericCommand
    {
        public override string Name => "hello";
        public override string Description => "Says hello world";
        public override string Author => "CloudRex <cloudrex@outlook.com>";
        public override string Version => "1.0.0";

        public override void Run(Context context)
        {
            context.Reply("Hello world!");
        }
    }
}
