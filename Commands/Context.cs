using DNet.Core;
using DNet.Structures;

namespace DNet.Commands
{
    public class Context
    {
        // TODO: Should be readonly
        public Bot Bot { get; set; }
        public Message Message { get; set; }

        public void Reply(string message, bool mention = true)
        {
            this.Bot.Client.CreateMessage(this.Message.channelId, mention ? $"<@{this.Message.author.id}>, {message}" : message);
        }
    }
}