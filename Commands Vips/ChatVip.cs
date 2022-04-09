using System;
using System.Collections.Generic;
using System.Linq;
using CommandSystem;
using Exiled.Permissions.Extensions;
using Player = Exiled.API.Features.Player;

namespace Vips.Commands_Vips
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Chat : ICommand
    {
        public string Command { get; } = "chat";

        public string[] Aliases { get; } = new string[] { "ch" };

        public string Description { get; } = "vip";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("vips"))
            {
                response = "You do not have permissions to execute this command";
                return false;
            }
            Player sende = Player.Get(sender);
            IEnumerable<string> thing = arguments.Skip(0);
            string msg = "";
            foreach (string s in thing)
                msg += $"{s}";

            foreach (Player p in Player.List)
            {
                if (p.CheckPermission("vip"))
                {
                    p.ClearBroadcasts();
                    p.Broadcast(10, $"<i><color=blue>{sende.Nickname}:</color> {msg}</i>", Broadcast.BroadcastFlags.Normal, true);
                }
            }
            response = "Broadcast sent to all staffs/donors";
            return true;
        }
    }
}
