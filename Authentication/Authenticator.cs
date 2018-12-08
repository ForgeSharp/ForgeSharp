using ForgeSharp.Constraints;
using ForgeSharp.Commands;
using ForgeSharp.Core;
using System;

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

        public AuthLevel GetAuthLevel(Type type)
        {
            RequireAuthAttribute authRequirement = Utils.ExtractAttribute<RequireAuthAttribute>(type);

            return authRequirement != null ? authRequirement.level : AuthLevel.Default;
        }

        public AuthLevel GetAuthLevel(GenericCommand command)
        {
            return this.GetAuthLevel(command.GetType());
        }

        public ChatEnvironment GetChatEnvironment(Type type)
        {
            RequireEnvAttribute envRequirement = Utils.ExtractAttribute<RequireEnvAttribute>(type);

            return envRequirement != null ? envRequirement.environment : ChatEnvironment.Everywhere;
        }

        public ChatEnvironment GetChatEnvironment(GenericCommand command)
        {
            return this.GetChatEnvironment(command.GetType());
        }
    }
}
