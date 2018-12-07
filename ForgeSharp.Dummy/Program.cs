using DNet.API.Gateway;
using ForgeSharp.Core;
using ForgeSharp.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ForgeSharp.Dummy
{
    internal class Program
    {
        public static async Task<int> Main(string[] args)
        {
            // Attempt to load environment variables
            try
            {
                DotNetEnv.Env.Load();
            }
            catch (FileNotFoundException)
            {
                // TODO: Error
                Logger.Verbose("The .env file does not exist");

                return 1;
            }

            // Configure and start the bot
            Bot bot = new Bot(Environment.GetEnvironmentVariable("TOKEN"), new BotOptions() {
                Prefix = "fd!"
            });

            // Setup events
            bot.Client.GetHandle().OnReady += (object sender, ReadyEvent e) => {
                // TODO: Success
                Logger.Verbose("Bot is ready");
            };

            // Register commands
            bot.CommandHandler.RegisterMultipleByType(
                typeof(Commands.Hello),
                typeof(Premade.Commands.Ping),
                typeof(Premade.Commands.Stop)
            );

            // Register services
            bot.ServiceManager.RegisterMultipleByType(
                typeof(Services.DummyService)
            );

            await bot.Connect();

            // TODO: Application will not stop
            await Task.Delay(-1);

            return 0;
        }
    }
}
