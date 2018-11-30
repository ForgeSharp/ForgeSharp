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
            return $"<#{channelId}>";
        }

        public static string MentionRole(string roleId)
        {
            return $"<@&{roleId}>";
        }
    }
}
