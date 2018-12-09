using ForgeSharp.Core;
using DNet.Structures;
using System.Threading.Tasks;
using DNet.Structures.Messages;

namespace ForgeSharp.Commands
{
    public sealed class Context
    {
        // TODO: Should be readonly
        public Bot Bot { get; set; }

        public GenericMessage Message { get; set; }

        public CommandIssuer Issuer { get; set; }

        public Task<Message> Reply(string message, bool mention = false)
        {
            // TODO: Verified email?
            return this.Bot.Client.toolbox.CreateMessage(this.Message.ChannelId, mention ? $"{Utils.Mention(this.Message.Author.Id)}, {message}" : message);
        }
    }
}