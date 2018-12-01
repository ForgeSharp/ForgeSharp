using ForgeSharp.Commands;
using ForgeSharp.Fragments;

namespace DummyForgeSharpBot.Commands
{
    [FragmentIdentifier("hello")]
    public class Hello : GenericCommand
    {
        public override string Name => "hello";
        public override string Description => "Says hello world";
        public override string Author => "CloudRex <cloudrex@outlook.com>";
        public override string Version => "1.0.0";

        public override void Run(Context context)
        {
            context.Bot.Client.CreateMessage(context.Message.ChannelId, "Hello world!");
        }
    }
}
