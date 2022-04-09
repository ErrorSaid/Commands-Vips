using System;
using CommandSystem;
using Exiled.Permissions.Extensions;
using Exiled.API.Features;

namespace Vips.Commands_Vips
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Invisible : ICommand
    {
        public string Command { get; } = "Invisible";

        public string[] Aliases { get; } = new string[] { "invs" };

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
            if (p.IsInvisible)
            {
                p.IsInvisible = false;
                response = "Done";
                return true;
            }
            p.IsInvisible = true;
            response = "Done";
            return true;
        }
    }
}
