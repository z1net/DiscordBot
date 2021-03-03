using DiscordBot.Core.Attributes;
using DiscordBot.Core.Helper;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace DiscordBotTutorial.Core.Commands
{
    [RegisterCommand]
    public class BotCommandUptime : BaseCommandModule
    {
        [Command("uptime")]
        public async Task ExecuteCommandUptime(CommandContext context)
        {
            if (context.Channel.Equals(BotHelper.BotChat))
            {
                DiscordEmbedBuilder embedBuilder = new DiscordEmbedBuilder
                {
                    Title = BotHelper.GetUptime(),

                    Author = new DiscordEmbedBuilder.EmbedAuthor
                    {
                        IconUrl = context.User.AvatarUrl,
                        Name = context.User.Username,
                    },
                    Color = DiscordColor.CornflowerBlue,
                };

                await context.RespondAsync(embed: embedBuilder).ConfigureAwait(false);
            }
        }
    } 
}
