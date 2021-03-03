using DSharpPlus;
using DSharpPlus.Entities;
using System;

namespace DiscordBot.Core.Helper
{
    public class BotHelper
    {
        public static DiscordClient Client => BotHelper.Client;

        public static DiscordGuild Guild => DiscordBot.Core.Bot.Bot.Client.Guilds[814585147008483328];

        public static DiscordChannel MainChat => GetChannelById(814608666254770188);

        public static DiscordChannel BotChat => GetChannelById(814860197578670110);

        public static DiscordChannel AnnouncesChat => GetChannelById(814589592073797642);

        public static DiscordChannel MembersChannel => GetChannelById(815744488046723103);

        public static Random Random = new Random();



        #region Property`s



        public static int Ping => Bot.Bot.Client.Ping;

        public static ulong Id => BotHelper.Guild.CurrentMember.Id;



        #endregion



        #region Methods
        public static int GetMembersCount()
        {
            return Guild.MemberCount;
        }

        public static DiscordChannel GetChannelById(ulong id)
        {
            return Guild.GetChannel(id);
        }

        public static string GetUserDiscord(DiscordUser user)
        {
            return (user.Username + "#" + user.Discriminator);
        }

        public static string GetUptime()
        {
            TimeSpan time = (DateTime.Now - DiscordBot.Core.Bot.Bot.Instance.Parameters.InitializeTime);

            return $"{time.Days} days, {time.Hours} hours, {time.Minutes} min, {time.Seconds} sec";
        }
        #endregion
    }
} 
