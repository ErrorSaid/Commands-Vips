using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace Vips.Commands_Vips
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Tutorial : ICommand
    {
        public string Command { get; } = "Tutorial";

        public string[] Aliases { get; } = new string[] { "tuto" };

        public string Description { get; } = "vip";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("vips"))
            {
                response = "You do not have permissions to execute this command";
                return false;
            }
            Player p = Player.Get((CommandSender)sender);
            if (p.Role.Type == RoleType.Spectator)
            {
                p.SetRole(RoleType.Tutorial);
                response = "Ready";
                return true;
            }
            if (p.Role.Type == RoleType.Tutorial)
            {
                p.SetRole(RoleType.Spectator);
                response = "Ready";
                return true;
            }
            response = "";
            return false;
        }
    }
}
