using ForgeSharp.Attributes;
using ForgeSharp.Commands;
using ForgeSharp.Core;
using System;
using System.Linq;

namespace ForgeSharp.Authentication
{
    // TODO
    public sealed class Authenticator
    {
        private readonly Bot bot;

        public Authenticator(Bot bot)
        {
            this.bot = bot;
        }

        public bool Authenticate(GenericCommand command, Context context)
        {
            // TODO: Improve auth checks
            if (this.GetAuthLevel(command) == AuthLevel.BotOwner
                && context.Issuer.User.Id != context.Bot.Options.OwnerId)
            {
                return false;
            }

            return true;
        }

        public AuthLevel GetAuthLevel(Type signature)
        {
            RequireAuthAttribute authRequirement = signature
                .GetCustomAttributes(typeof(RequireAuthAttribute), true)
                .FirstOrDefault() as RequireAuthAttribute;

            if (authRequirement != null)
            {
                return authRequirement.level;
            }

            return AuthLevel.Default;
        }

        public AuthLevel GetAuthLevel(GenericCommand command)
        {
            return this.GetAuthLevel(command.GetType());
        }
    }
}
