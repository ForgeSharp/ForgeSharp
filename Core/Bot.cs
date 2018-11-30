using System;
using System.Threading.Tasks;
using ForgeSharp.Commands;
using DNet.Structures;
using DNet;
using DNet.Socket;

namespace ForgeSharp.Core
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
            SocketHandle handle = this.Client.GetHandle();

            handle.OnMessageCreate += (object sender, Message message) =>
            {
                if (message.Content.StartsWith(this.Options.Prefix))
                {
                    string commandBase = CommandParser.GetBase(message.Content, this.Options.Prefix);

                    if (this.CommandHandler.IsRegistered(commandBase))
                    {
                        if (!this.CommandHandler.Run(commandBase, new Context()
                        {
                            Bot = this,
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