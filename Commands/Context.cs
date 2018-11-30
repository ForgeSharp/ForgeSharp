using ForgeSharp.Core;
using DNet.Structures;

namespace ForgeSharp.Commands
{
    public class Context
    {
        // TODO: Should be readonly
        public Bot Bot { get; set; }
        public Message Message { get; set; }

        public void Reply(string message, bool mention = true)
        {
            this.Bot.Client.CreateMessage(this.Message.ChannelId, mention ? $"<@{this.Message.Author.Id}>, {message}" : message);
        }
    }
}