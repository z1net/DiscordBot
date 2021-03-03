using DiscordBot.Core.Attributes;
using DiscordBot.Core.Helper;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace DiscordBotTutorial.Core.Commands
{
    [RegisterCommand]
    public class BotCommandRoll : BaseCommandModule
    {



        public readonly string[] ImagesURL =
        {
            "https://www.roulette17.com/images/random-number.gif",
            "https://media.giphy.com/media/E2UlE5Of9zEjK/giphy.gif",
            "https://media.giphy.com/media/l2SpYSNrKPONySXYY/giphy.gif",
            "https://media.giphy.com/media/3o6MbqNPaatT8nnEmk/giphy.gif",
            "https://media.giphy.com/media/fSSJUQNZOSJgsx7j8e/giphy.gif",
            "https://media.giphy.com/media/dvrtzp0tT25TbNfon4/giphy.gif",
            "https://media.giphy.com/media/U3IUsRtXuBEwQP8O0n/giphy.gif",
            "https://media.giphy.com/media/69ANfjkDPdEoQCxrse/giphy.gif",
        };



        public string GetRandomImageURL()
        {
            return ImagesURL[BotHelper.Random.Next(0, ImagesURL.Length)];
        }



        [Command("roll")]
        public async Task ExecuteCommandRoll(CommandContext context, int minValue = -1, int maxValue = -1)
        {
            if (context.Channel.Equals(BotHelper.BotChat))
            {
                int value = 0;

                DiscordEmbedBuilder embedBuilder = null;
                if (minValue == -1 || maxValue == -1 /*|| minValue == -1 && maxValue == -1*/) // args is null
                {
                    value = BotHelper.Random.Next(1, 100);

                    embedBuilder = new DiscordEmbedBuilder
                    {
                        Title = $"Rolled (0/100): {value}",
                        ImageUrl = GetRandomImageURL(),

                        Author = new DiscordEmbedBuilder.EmbedAuthor
                        {
                            IconUrl = context.User.AvatarUrl,
                            Name = context.User.Username,
                        },
                        Color = DiscordColor.CornflowerBlue,
                    };
                }
                else
                {
                    value = BotHelper.Random.Next(minValue, maxValue);

                    embedBuilder = new DiscordEmbedBuilder
                    {
                        Title = $"Rolled ({minValue}/{maxValue}): {value}",
                        ImageUrl = GetRandomImageURL(),

                        Author = new DiscordEmbedBuilder.EmbedAuthor
                        {
                            IconUrl = context.User.AvatarUrl,
                            Name = context.User.Username,
                        },
                        Color = DiscordColor.CornflowerBlue,
                    };
                }

                await context.RespondAsync(embed: embedBuilder);
            }
        }
    }
}
