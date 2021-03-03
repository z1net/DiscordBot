using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace DiscordBot.Core.Helper
{
    /// <summary>
    /// For execute messages in specific chat`s.
    /// </summary>
    public class BotMessager
    {



        /// <summary>
        /// Send message to arleady knows channel.
        /// </summary>
        public static async Task SendMessage(string content, Channel channel)
        {
            if (channel == Channel.Bot)
            {
                await BotHelper.BotChat.SendMessageAsync(content);
            }
            else if (channel == Channel.General)
            {
                await BotHelper.MainChat.SendMessageAsync(content);
            }
        }



        /// <summary>
        /// Send message to arleady knows channel with DiscordEmbed.
        /// </summary>
        public static async Task SendMessage(string content, DiscordEmbed embed, Channel channel)
        {
            if (channel == Channel.Bot)
            {
                await BotHelper.BotChat.SendMessageAsync(content, embed);
            }
            else if (channel == Channel.General)
            {
                await BotHelper.MainChat.SendMessageAsync(content, embed);
            }
        }



        /// <summary>
        /// Clear arleady knows channels.
        /// </summary>
        public static async Task ClearChannel(Channel channel, int limit = 100)
        {
            if (channel == Channel.General)
            {
                await BotHelper.BotChat.DeleteMessagesAsync(BotHelper.MainChat.GetMessagesAsync(limit).Result);
            }

            if (channel == Channel.Bot)
            {
                await BotHelper.BotChat.DeleteMessagesAsync(BotHelper.BotChat.GetMessagesAsync().Result);
            }
        }



        /// <summary>
        /// Clear channel by messages count.
        /// </summary>
        public static async Task ClearChannel(ulong id, int limit = 100)
        {
            DiscordChannel channel = null;
            if ((channel = BotHelper.GetChannelById(id)) != null)
            {
                await channel.DeleteMessagesAsync(channel.GetMessagesAsync(limit).Result);
            }
        }



        /// <summary>
        /// Clear all channel from messages.
        /// </summary>
        public static async Task ClearChannel(ulong id)
        {
            DiscordChannel channel = null;
            if ((channel = BotHelper.GetChannelById(id)) != null)
            {
                await channel.DeleteMessagesAsync(channel.GetMessagesAsync(channel.GetMessagesAsync().Result.Count).Result);
            }
        }



        /// <summary>
        /// Send error message.
        /// </summary>
        public static DiscordEmbedBuilder SendErrorMesage(string content = "Invalid command, try again.", string iconUrl = "https://icons.iconarchive.com/icons/paomedia/small-n-flat/128/sign-error-icon.png")
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder
            {
                Author = new DiscordEmbedBuilder.EmbedAuthor
                {
                    IconUrl = iconUrl,
                    Name = content,
                },
                Color = DiscordColor.Red,
            };

            return embed;
        }



        public enum Channel
        {
            General,
            Bot,
        }
    }
}
