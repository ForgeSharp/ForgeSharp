using DNet.Structures;

namespace DNet.Commands {
    public static class CommandParser
    {
        public static string GetBase(string commandString, string prefix)
        {
            return commandString.Split(prefix)[1].Split(" ")[0];
        }

        public static string GetBase(Message message, string prefix)
        {
            return CommandParser.GetBase(message.content, prefix);
        }
    }
}