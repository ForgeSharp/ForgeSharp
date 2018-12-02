using ForgeSharp.Core;
using DNet.Structures;
using DNet.Core;
using System.Threading.Tasks;

namespace ForgeSharp.Commands
{
    public class Context
    {
        // TODO: Should be readonly
        public Bot Bot { get; set; }
        public Message Message { get; set; }

        public Task<Message> Reply(string message, bool mention = false)
        {
            // TODO: Verified email?
            return this.Bot.Client.toolbox.CreateMessage(this.Message.ChannelId, mention ? $"{Utils.Mention(this.Message.Author.Id)}, {message}" : message);
        }
    }
}