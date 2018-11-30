using DNet.Structures;

namespace ForgeSharp.Commands {
    public static class CommandParser
    {
        public static string GetBase(string commandString, string prefix)
        {
            if (commandString == null || prefix == null)
            {
                return null;
            }

            string[] split = commandString.Split(prefix);

            if (split.Length > 1)
            {
                return split[1].Split(" ")[0];
            }

            return split[0];
        }

        public static string GetBase(Message message, string prefix)
        {
            return CommandParser.GetBase(message.Content, prefix);
        }
    }
}