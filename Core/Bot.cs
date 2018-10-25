using System;
using System.Threading.Tasks;
using DNet.Commands;
using DNet.Structures;

namespace DNet.Core
{
    public struct BotOptions
    {
        public string Prefix { get; set; }
        public bool IgnoreBots { get; set; }
    }

    public class Bot
    {
        public readonly string Token;
        public readonly CommandHandler CommandHandler;
        public readonly Client Client;
        public readonly BotOptions Options;

        public Bot(string token, BotOptions options)
        {
            this.Token = token;
            this.Options = options;
            this.Client = new Client();
            this.CommandHandler = new CommandHandler();

            // Setup
            this.SetupEvents();
        }

        private void SetupEvents()
        {
            var handle = this.Client.GetHandle();

            handle.OnMessageCreate += (Message message) =>
            {
                if (message.content.StartsWith(this.Options.Prefix))
                {
                    var commandBase = CommandParser.GetBase(message.content, this.Options.Prefix);

                    System.Console.WriteLine($"Command base: {commandBase}");

                    if (this.CommandHandler.IsRegistered(commandBase))
                    {
                        System.Console.WriteLine("Is registered");
                        if (!this.CommandHandler.RunIgnoringConditions(commandBase, new Context()
                        {
                            Bot = Program.Bot,
                            Message = message
                        }))
                        {
                            Console.WriteLine($"Command '{commandBase}' failed to run");
                        }
                    }
                }
            };
        }

        public Task Connect()
        {
            return this.Client.Connect(this.Token);
        }
    }
}