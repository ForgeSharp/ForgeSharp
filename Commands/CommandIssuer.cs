using DNet.Structures;
using DNet.Structures.Guilds;
using ForgeSharp.Core;

namespace ForgeSharp.Commands
{
    public struct CommandIssuer
    {
        public User User { get; set; }

        public GuildMember? Member { get; set; }

        public AuthLevel Level { get; set; }
    }
}
