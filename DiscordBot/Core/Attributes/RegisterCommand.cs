using System;

namespace DiscordBot.Core.Attributes
{
    /// <summary>
    /// It`s for auto-reg commands.
    /// </summary>

    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterCommand : Attribute
    {

    }
}
