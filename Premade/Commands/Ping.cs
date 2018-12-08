using DNet.Structures;
using ForgeSharp.Commands;
using ForgeSharp.Fragments;
using System.Diagnostics;

namespace ForgeSharp.Premade.Commands
{
    public class Ping : Command
    {
        public override Meta Meta => new Meta
        {
            Name = "ping",
            Description = "Displays the bot's latency"
        };

        // TODO: Measure time
        public override async void Run(Context context)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            Message msg = await context.Reply("Ping?");

            if (msg != null)
            {
                stopWatch.Stop();
                await msg.Edit($":ping_pong: Pong! ~{stopWatch.ElapsedMilliseconds}ms");
            }
        }
    }
}
