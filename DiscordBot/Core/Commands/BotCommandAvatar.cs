using DiscordBot.Core.Attributes;
using DiscordBot.Core.Helper;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Threading.Tasks;

namespace DiscordBot.Core.Commands
{
    [RegisterCommand]
    public class BotCommandAvatar : BaseCommandModule
    {
        [Command("avatar")]
        public async Task ExecuteCommandAvatar(CommandContext context, DiscordMember member = null)
        {
            if (context.Channel.Equals(BotHelper.BotChat))
            {
                DiscordEmbedBuilder embedBuilder = null;
                if (member != null)
                {
                    embedBuilder = new DiscordEmbedBuilder
                    {
                        Title = "Avatar",
                        ImageUrl = member.AvatarUrl,

                        Author = new DiscordEmbedBuilder.EmbedAuthor
                        {
                            IconUrl = member.AvatarUrl,
                            Name = member.Username,
                        },
                        Color = DiscordColor.CornflowerBlue,
                    };
                }
                else
                {
                    embedBuilder = new DiscordEmbedBuilder
                    {
                        Title = "Avatar",
                        ImageUrl = context.User.AvatarUrl,

                        Author = new DiscordEmbedBuilder.EmbedAuthor
                        {
                            IconUrl = context.User.AvatarUrl,
                            Name = context.User.Username,
                        },
                        Color = DiscordColor.CornflowerBlue,
                    };
                }

                await context.RespondAsync(embed: embedBuilder).ConfigureAwait(false);
            }
        }
    }
}
