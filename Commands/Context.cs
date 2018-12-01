using ForgeSharp.Core;
using DNet.Structures;

namespace ForgeSharp.Commands
{
    public class Context
    {
        // TODO: Should be readonly
        public Bot Bot { get; set; }
        public Message Message { get; set; }

        public void Reply(string message, bool mention = false)
        {
            // TODO: Verified email?
            this.Bot.Client.CreateMessage(this.Message.ChannelId, mention ? $"{Utils.Mention(this.Message.Author.Id)}, {message}" : message);
        }
    }
}