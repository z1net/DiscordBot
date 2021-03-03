using DiscordBot.Core.Attributes;
using DiscordBot.Core.Helper;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace DiscordBot.Core.Commands
{
    [RegisterCommand]
    public class BotCommandClear : BaseCommandModule
    {
        [Command("clear")]
        [RequireRoles(RoleCheckMode.All, "Admin")]
        public async Task ExecuteCommandClear(CommandContext context, int limit = 5)
        {
            DiscordEmbedBuilder embedBuilder = new DiscordEmbedBuilder
            {
                Title = $"Chat cleared ({limit}m.)",

                Author = new DiscordEmbedBuilder.EmbedAuthor
                {
                    IconUrl = context.User.AvatarUrl,
                    Name = context.User.Username,
                },
                Color = DiscordColor.CornflowerBlue,
            };


            await BotMessager.ClearChannel(context.Channel.Id, limit);

            await context.RespondAsync(embed: embedBuilder).ConfigureAwait(false);
        }
    }
}
