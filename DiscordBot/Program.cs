using DiscordBot.Core.Bot;

namespace DiscordBot
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Bot bot = new Bot();

            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
