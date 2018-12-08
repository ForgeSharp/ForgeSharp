using System;
using System.Threading.Tasks;
using ForgeSharp.Commands;
using DNet.Structures;
using DNet.API;
using ForgeSharp.Services;
using DNet.ClientStructures;
using ForgeSharp.Logging;
using ForgeSharp.Authentication;

namespace ForgeSharp.Core
{
    public class BotOptions
    {
        public string Prefix { get; set; } = "!";

        public bool IgnoreBots { get; set; } = true;

        public bool CaseSensitive { get; set; } = true;

        public bool AnsciiLogo { get; set; } = true;

        public string OwnerId { get; set; }
    }

    public class Bot : IDisposable
    {
        private readonly string AnsciiLogo = @"
 ███████╗ ██████╗ ██████╗  ██████╗ ███████╗
 ██╔════╝██╔═══██╗██╔══██╗██╔════╝ ██╔════╝
 █████╗  ██║   ██║██████╔╝██║  ███╗█████╗  
 ██╔══╝  ██║   ██║██╔══██╗██║   ██║██╔══╝  
 ██║     ╚██████╔╝██║  ██║╚██████╔╝███████╗
 ╚═╝      ╚═════╝ ╚═╝  ╚═╝ ╚═════╝ ╚══════╝" + "\n";

        // TODO: Use this event
        public event EventHandler<ClientState> OnStateChange;

        private static readonly BotOptions defaultBotOptions = new BotOptions()
        {
            //
        };

        public readonly string Token;
        public readonly CommandHandler CommandHandler;
        public readonly ServiceManager ServiceManager;
        public readonly Authenticator Authenticator;
        public readonly Client Client;
        public readonly BotOptions Options;

        public Bot(string token, BotOptions options)
        {
            this.Token = token;
            this.Options = options;
            this.Client = new Client();
            this.Authenticator = new Authenticator(this);
            this.CommandHandler = new CommandHandler(this);
            this.ServiceManager = new ServiceManager(this);

            // Setup
            this.SetupEvents();
        }

        public Bot(string token) : this(token, Bot.defaultBotOptions)
        {
            //
        }

        private void SetupEvents()
        {
            SocketHandle handle = this.Client.GetHandle();

            handle.OnMessageCreate += this.HandleMessage;
        }

        private void HandleMessage(object sender, Message message)
        {
            // TODO: Message.Content should be automatically trimmed by DNet upon being received
            // Ignore empty messages
            if (message.Content == null)
            {
                return;
            }
            // Ignore bots
            else if (this.Options.IgnoreBots && message.Author.Bot == true)
            {
                return;
            }
            else if (message.Content.StartsWith(this.Options.Prefix))
            {
                string commandBase = CommandParser.GetBase(message.Content, this.Options.Prefix);

                if (!this.Options.CaseSensitive)
                {
                    commandBase = commandBase.ToLower();
                }

                if (this.CommandHandler.IsRegistered(commandBase))
                {
                    if (!this.CommandHandler.Run(commandBase, new Context
                    {
                        Bot = this,
                        Message = message,

                        Issuer = new CommandIssuer {
                            Level = CommandHandler.DetermineAuthLevel(message.Author),
                            Member = message.Member,
                            User = message.Author
                        }
                    }))
                    {
                        // TODO: Warning?
                        Logger.Verbose($"Command '{commandBase}' failed to run");
                    }
                }
            }
        }

        public Task Connect()
        {
            if (this.Options.AnsciiLogo)
            {
                Console.WriteLine(this.AnsciiLogo);
            }

            // Start services
            if (this.ServiceManager.Count > 0)
            {
                int started = this.ServiceManager.StartAll();

                Logger.Verbose($"Started {started}/{this.ServiceManager.Count} services");
            }

            return this.Client.Connect(this.Token);
        }

        public void Shutdown(int code = 0)
        {
            this.Dispose();
            Environment.Exit(code);
        }

        // TODO: Figure a way to provide a callback for all the events inside (delegate)
        public void Dispose()
        {
            // TODO: Stop the client
            this.Client.Dispose();

            // Stop all services
            this.ServiceManager.StopAll();
        }
    }
}