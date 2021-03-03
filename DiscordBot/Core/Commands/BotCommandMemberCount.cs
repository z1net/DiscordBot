using DiscordBot.Core.Attributes;
using DiscordBot.Core.Helper;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace DiscordBot.Core.Commands
{
    [RegisterCommand]
    public class BotCommandMemberCount : BaseCommandModule
    {
        [Command("members")]
        public async Task ExecuteCommandMembersCount(CommandContext context)
        {
            if (context.Channel.Equals(BotHelper.BotChat))
            {
                DiscordEmbedBuilder embedBuilder = new DiscordEmbedBuilder
                {
                    Title = $"Members on server: {BotHelper.GetMembersCount()}",

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
