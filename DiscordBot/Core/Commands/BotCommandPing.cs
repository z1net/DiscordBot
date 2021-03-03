using DiscordBot.Core.Attributes;
using DiscordBot.Core.Helper;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace DiscordBot.Core.Commands
{
    [RegisterCommand]
    public class BotCommandPing : BaseCommandModule
    {



        public readonly string[] ImagesURL =
        {
            "https://media1.tenor.com/images/d0bbcb0309236de3f31914adf098a69d/tenor.gif?itemid=7484357",
            "https://media1.tenor.com/images/22ca599dff66b107b44a12e968e49352/tenor.gif?itemid=18905873",
            "https://media.giphy.com/media/3o6ZsX2OZJ8G3Tec6Y/giphy.gif",
            "https://media.giphy.com/media/9J7tdYltWyXIY/giphy.gif",
            "https://media.giphy.com/media/14uQ3cOFteDaU/giphy.gif",
        };



        public string GetRandomImageURL()
        {
            return ImagesURL[BotHelper.Random.Next(0, ImagesURL.Length)];
        }



        [Command("ping")]
        public async Task ExecuteCommandPing(CommandContext context)
        {
            if (context.Channel.Equals(BotHelper.BotChat))
            {
                DiscordEmbedBuilder embedBuilder = new DiscordEmbedBuilder
                {
                    Title = Bot.Bot.Client.Ping.ToString(),
                    ImageUrl = GetRandomImageURL(),

                    Author = new DiscordEmbedBuilder.EmbedAuthor
                    {
                        IconUrl = context.User.AvatarUrl,
                        Name = context.User.Username,
                    },
                    Color = DiscordColor.CornflowerBlue,
                };

                await context.RespondAsync(embed: embedBuilder);
            }
        }
    }
}
