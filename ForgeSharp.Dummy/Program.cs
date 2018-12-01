using ForgeSharp.Core;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DummyForgeSharpBot
{
    public class Program
    {
        public static int Main(string[] args)
        {
            // Attempt to load environment variables
            try
            {
                DotNetEnv.Env.Load();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The .env file does not exist");

                return 1;
            }

            // Configure and start the bot
            Bot bot = new Bot(Environment.GetEnvironmentVariable("TOKEN"), new BotOptions() {
                Prefix = "fd!"
            });

            // Setup events
            bot.Client.GetHandle().OnReady += (object sender, EventArgs e) => {
                Console.WriteLine("Bot is ready");
            };

            // Register commands
            bot.CommandHandler.RegisterMultipleByType(
                typeof(Commands.Hello)
            );

            // TODO: Application will not stop
            Task.WaitAll(Task.Run(bot.Connect));
            Console.WriteLine("==> Connect finished");
            Task.WaitAll(Task.Delay(-1));

            return 0;
        }
    }
}
