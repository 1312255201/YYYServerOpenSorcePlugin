using CommandSystem;
using Exiled.API.Features;
using RemoteAdmin;
using System;

namespace YYYServerOpenSorcePlugin.Command
{
	[CommandHandler(typeof(ClientCommandHandler))]
	public class suicide : ICommand
	{
		public string Command { get; } = "suicide";
		public string[] Aliases { get; } = new string[] { "zisha" ,"banzai"};
		public string Description { get; } = "自杀";
		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (sender is PlayerCommandSender)
			{
				var plr = sender as PlayerCommandSender;
				Player.Get(plr.PlayerId).Kill("自杀了");
				response = "执行完毕";
				return true;
			}
			response = "未知错误";
			return false;

		}
	}
}
