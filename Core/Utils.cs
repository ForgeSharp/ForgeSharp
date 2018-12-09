using DNet.Structures;
using DNet.Structures.Channels;
using DNet.Structures.Messages;
using ForgeSharp.Commands;
using System;
using System.Linq;

namespace ForgeSharp.Core
{
    public static class Utils
    {
        public static string Mention(string userId, bool verifiedEmail = true)
        {
            if (userId == null)
            {
                return null;
            }

            string result = "<@";

            if (!verifiedEmail)
            {
                result += "!";
            }

            return $"{result}{userId}>";
        }

        public static string MentionChannel(string channelId)
        {
            if (channelId == null)
            {
                return null;
            }

            return $"<#{channelId}>";
        }

        public static string MentionRole(string roleId)
        {
            if (roleId == null)
            {
                return null;
            }

            return $"<@&{roleId}>";
        }

        public static T ExtractAttribute<T>(Type type) where T : Attribute
        {
            return type
                .GetCustomAttributes(typeof(T), true)
                .FirstOrDefault() as T;
        }

        public static ChatEnvironment? DetermineChatEnvironment(Channel channel)
        {
            if (channel == null)
            {
                return null;
            }

            switch (channel.Type)
            {
                case ChannelType.DM:
                    {
                        return ChatEnvironment.DM;
                    }

                case ChannelType.Group:
                    {
                        return ChatEnvironment.Group;
                    }

                case ChannelType.Text:
                    {
                        TextChannel textChannel = (TextChannel)channel;

                        if (textChannel.NSFW)
                        {
                            return ChatEnvironment.Nsfw;
                        }

                        return ChatEnvironment.Guild;
                    }

                default:
                    {
                        throw new InvalidOperationException("Cannot determine chat environment of an invalid channel");
                    }
            }
        }

        public static ChatEnvironment? DetermineChatEnvironment(GenericMessage message)
        {
            return Utils.DetermineChatEnvironment(message.Channel);
        }

        public static ChatEnvironment? DetermineChatEnvironment(Context context)
        {
            return Utils.DetermineChatEnvironment(context.Message);
        }

        // TODO: bool IsTextBasedChannel()
    }
}
