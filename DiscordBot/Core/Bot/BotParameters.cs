using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTutorial.Core.Bot
{
    public struct BotParameters
    {
        public DateTime InitializeTime { get; }



        public BotParameters(DateTime time)
        {
            InitializeTime = time;
        }
    }
}
