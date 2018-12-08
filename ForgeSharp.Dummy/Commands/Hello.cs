using ForgeSharp.Commands;
using ForgeSharp.Fragments;

namespace ForgeSharp.Dummy.Commands
{
    internal class Hello : Command
    {
        public override Meta Meta => new Meta
        {
            Name = "hello"
        };

        public override void Run(Context context)
        {
            context.Reply("Hello world!");
        }
    }
}
