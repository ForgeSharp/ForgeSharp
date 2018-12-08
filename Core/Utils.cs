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
                .GetCustomAttributes(type, true)
                .FirstOrDefault() as T;
        }
    }
}
