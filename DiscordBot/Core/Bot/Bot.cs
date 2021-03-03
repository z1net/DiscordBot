using DiscordBot.Core.Attributes;
using DiscordBot.Core.Helper;
using DiscordBotTutorial.Core.Bot;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DiscordBot.Core.Bot
{
    public class Bot
    {
        public static Bot Instance;

        public static DiscordClient Client { get; private set; }

        public static CommandsNextConfiguration Configuration { get; private set; }

        public static CommandsNextExtension Commands { get; private set; }

        public BotParameters Parameters { get; }



        public Bot()
        {
            Instance = this;

            Parameters = new BotParameters(DateTime.Now);
        }



        public async Task RunAsync()
        {
            

            DiscordConfiguration parameters = new DiscordConfiguration
            {
                Token = "",
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
            };



            Client = new DiscordClient(parameters);

            Configuration = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { "!" },
                EnableDms = false,
                EnableMentionPrefix = true,
                DmHelp = true,
            };



            Commands = Client.UseCommandsNext(Configuration);



            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsDefined(typeof(RegisterCommand), false))
                {
                    Commands.RegisterCommands(type);
                }
            }



            Client.Ready += onClientReady;



            await Client.ConnectAsync();

            await Task.Delay(-1);
        }



        private Task onClientReady(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
