using DiscordBot.Core.Attributes;
using DiscordBot.Core.Helper;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace DiscordBot.Core.Commands
{
    [RegisterCommand]
    public class BotCommandFlip : BaseCommandModule
    {
        // Good Site for flip gif`s: https://acegif.com/ru/gifki-vrashhajushhejsja-monety/



        public readonly string[] ImagesURL =
        {
            "https://acegif.com/wp-content/gifs/coin-flip-16.gif",
            "https://acegif.com/wp-content/gifs/coin-flip-24.gif",
            "https://acegif.com/wp-content/gifs/coin-flip-18.gif",
            "https://acegif.com/wp-content/gifs/coin-flip-10.gif",
            "https://acegif.com/wp-content/gifs/coin-flip-13.gif",
            "https://acegif.com/wp-content/gifs/coin-flip-7.gif",
            "https://acegif.com/wp-content/gifs/coin-flip-15.gif",

        };


        
        public string GetRandomImageURL()
        {
            return ImagesURL[BotHelper.Random.Next(0, ImagesURL.Length)];
        }



        [Command("flip")]
        public async Task ExecuteCommandFlip(CommandContext context)
        {
            if (context.Channel.Equals(BotHelper.BotChat))
            {
                int value = BotHelper.Random.Next(1, 100);

                DiscordEmbedBuilder embedBuilder = new DiscordEmbedBuilder
                {
                    Title = (value <= 50 ? "Решка" : "Орел"),
                    ImageUrl = GetRandomImageURL(),

                    Author = new DiscordEmbedBuilder.EmbedAuthor
                    {
                        IconUrl = context.User.AvatarUrl,
                        Name = context.User.Username,
                    },
                    Color = DiscordColor.CornflowerBlue,
                };

                await context.Channel.SendMessageAsync(embed: embedBuilder).ConfigureAwait(false);
            }
        }
    }
}
