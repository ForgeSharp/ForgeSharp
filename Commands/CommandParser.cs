using DNet.Structures;
using System;
using System.Linq;

namespace ForgeSharp.Commands {
    public static class CommandParser
    {
        public static string GetBase(string commandString, string prefix)
        {
            if (commandString == null || prefix == null)
            {
                return null;
            }

            return commandString.Substring(prefix.Length).Split(" ")[0];
        }

        // TODO: Add support for quoted arguments, ex. "hello world"
        public static string[] GetArguments(string commandString)
        {
            if (commandString == null)
            {
                return null;
            }

            return commandString.Trim().Split(" ").Skip(1).ToArray();
        }

        public static string GetBase(Message message, string prefix)
        {
            return CommandParser.GetBase(message.Content, prefix);
        }
    }
}