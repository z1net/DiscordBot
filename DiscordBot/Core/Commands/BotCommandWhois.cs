using DiscordBot.Core.Attributes;
using DiscordBot.Core.Helper;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace DiscordBotTutorial.Core.Commands
{
    [RegisterCommand]
    public class BotCommandWhois : BaseCommandModule
    {



        public readonly string[] ImagesURL =
        {
            "https://psv4.userapi.com/c536236/u189095609/docs/d15/e2e83b23b627/6919247553850625285.gif?extra=QNoUvnQSmPw-frueDKf5Np8Rp3vEvEqWcCnejpcv4nBcwckXbzkRi4XjO2VT3112v0uqvbe6kRD6cTD_4r7U5-6JZBTz26bzX61MgshVqbB0cvem_1F746ybw7wm-1Kj1rBWORB5BWhT4D9_J0J9wHM",
            "https://psv4-71.userapi.com/c856220/u44610039/docs/d15/bef6db6ea486/2ute3.gif?extra=1qTyN9xOnkXiZmZRGgZH5rxy5_h0FGip943_M7vQUdB0MyFQSgouMRDnVwNFK0mXlAcfvuCki2WpgK3yJHCnTgUXnb9AcvgqTYdQzGuPiCKJdu32WhQvlKSzNSfIVqzYz_TjAcnKq-EKA3plcw1J-5A",
            "https://cdn.discordapp.com/attachments/814860197578670110/814919059870711848/396e069f348f893f_1.gif",
            "https://psv4.userapi.com/c856220/u46864751/docs/d15/fb58e5dc7ef5/niggers.gif?extra=GmPFBGyn5w59OcXwkyE9jCVH9dKKoC94yN0AqCalUJW48X3hBiMZsF1Z7qUaO7R0AvnpX_8jmGqKq-Fp-4woORx2yuUk6BOulu7IO1BYocl45azFeYxrRpSWJwroVMJupCi33M-QIhLzj0BFE-wR7cY",
            "https://psv4.userapi.com/c856220/u572896049/docs/d10/64eb0794c76e/ezgif-2-27cefdf4ec59.gif?extra=LVRIi6evd5gD9dDNVjF1MRFys8Q5VbsxE4gSey0rukHdoCzkUZOj2gXa0UHesVG5iJgzU-5fZGcwLPSoFfnCS21zSVScZ1HAhpGuBEDI3q63ZCQvTDuFjC0OkyNkEG0eWf6N7vcRqk1IOxxyFL69NFo",
            "https://media.giphy.com/media/c6kb61eiE9fbNRZkGJ/giphy.gif",
            "https://media.giphy.com/media/2u11zpzwyMTy8/giphy.gif",
            "https://media.giphy.com/media/MFsqcBSoOKPbjtmvWz/giphy.gif",
            "https://media.giphy.com/media/NKSq1x79SPTGg/giphy.gif",
            "https://media.giphy.com/media/l0HlMh40gm8y0341a/giphy.gif",
            "https://media.giphy.com/media/26ufjyAvlCA94o2HK/giphy.gif",
            "https://media.giphy.com/media/l0MYFYlXCPots5xcs/giphy.gif",
            "https://media.giphy.com/media/37R8NFzRiynS1DeYpo/giphy.gif",
            "https://media.giphy.com/media/26BREXsMwJE4xorpS/giphy.gif",
            "https://media.giphy.com/media/OmK8lulOMQ9XO/giphy.gif",
            "https://media.giphy.com/media/H4DjXQXamtTiIuCcRU/giphy.gif",
            "https://media.giphy.com/media/4Iw2OzgiiTc4M/giphy.gif",
            "https://media.giphy.com/media/3oriO0OEd9QIDdllqo/giphy.gif",
            "https://media1.tenor.com/images/fef010b31cd6e99740798cf835aad492/tenor.gif?itemid=7730100",
            "https://media1.tenor.com/images/306d8d98a614d9b2e6903c6199fed943/tenor.gif?itemid=9256390",
            "https://media1.tenor.com/images/7aef40450e80c81946833b2a1a4172e6/tenor.gif?itemid=4570429",
            "https://media1.tenor.com/images/9a4d60fc3b438877a2dc36da0d066780/tenor.gif?itemid=9152583",
            "https://media1.tenor.com/images/65a52ac2ba167b924b16dbc7bdc25603/tenor.gif?itemid=14856115",
            "https://media.giphy.com/media/mRQxT7hSvNGnaHUkHt/giphy.gif",
            "https://media.giphy.com/media/NxiH75jojM1DnkQOhi/giphy.gif",
            "https://media.giphy.com/media/QqgogeceCH7q8jG3sg/giphy.gif",
            "https://media.giphy.com/media/vxqEVaN5jCiOUjN319/giphy.gif",
            "https://media.giphy.com/media/fOI8QfkEPQLR623XSW/giphy.gif",
            "https://media.giphy.com/media/L3WMP4mKKaQZaS2Wi5/giphy.gif",
            "https://media.giphy.com/media/StWWewaI2hfZwcgMCY/giphy.gif",
            "https://media.giphy.com/media/Y4trejKRhryW9FZsRW/giphy.gif",
            "https://media.giphy.com/media/hpR27uz9Nk3M9SFPSu/giphy.gif",
            "https://media.giphy.com/media/gr5qY4qj8G96o/giphy.gif",
            "https://media.giphy.com/media/cbWQm0HonZORq/giphy.gif",
            "https://media.giphy.com/media/PjU4kmpJg5yYDazoYJ/giphy.gif",
        };



        public string GetRandomImageURL()
        {
            return ImagesURL[BotHelper.Random.Next(0, ImagesURL.Length)];
        }



        [Command("whois")]
        public async Task ExecuteCommandWhois(CommandContext context, DiscordMember member = null)
        {
            if (context.Channel.Equals(BotHelper.BotChat))
            {
                DiscordEmbedBuilder embedBuilder = null;

                if (member == null)
                {
                   embedBuilder = BotMessager.SendErrorMesage("Invalid command, try: !whois @username");
                }
                else
                {
                    embedBuilder = new DiscordEmbedBuilder
                    {
                        Author = new DiscordEmbedBuilder.EmbedAuthor
                        {
                            IconUrl = member.AvatarUrl,
                            Name = member.Username,
                        },

                        ImageUrl = GetRandomImageURL(),
                        Color = DiscordColor.CornflowerBlue,
                    };
                }

                await context.Channel.SendMessageAsync(embed: embedBuilder).ConfigureAwait(false);
            }
        }
    }
}
