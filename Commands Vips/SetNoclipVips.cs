using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace Vips.Commands_Vips
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Noclip : ICommand
    {
        public string Command { get; } = "Noclip";

        public string[] Aliases { get; } = new string[] { "nc" };

        public string Description { get; } = "vip";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("vips"))
            {
                response = "You do not have permissions to execute this command";
                return false;
            }
            Player p = Player.Get((CommandSender)sender);
            if (p.Role != RoleType.Tutorial)
            {
                response = "you aren't a tutorial";
                return false;
            }
            if (p.NoClipEnabled)
            {
                p.NoClipEnabled = false;
                response = "Done";
                return true;
            }
            p.NoClipEnabled = true;
            response = "Done";
            return true;
        }
    }
}
