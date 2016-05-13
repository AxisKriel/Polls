using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShockAPI;
using TerrariaApi.Server;
using Polls.DB;
using System.Text.RegularExpressions;

namespace Polls
{
	public class Commands
	{
		public static void DoPoll(CommandArgs args)
		{
			if (args.Parameters.Count < 1)
			{
				args.Player.SendInfoMessage("Run a pre-defined poll or create one on the fly.");
				args.Player.SendInfoMessage($"Syntax: {TShockAPI.Commands.Specifier}poll [switch] <name/id> [custom duration]");
				args.Player.SendInfoMessage($"Type {TShockAPI.Commands.Specifier}poll -? for more info.");
			}
			else
			{
				var switchExp = new Regex(@"-(?:(?<Switch>[cC?])|-(?<Word>[a-zA-Z_-]+))");
				Match switchMatch = switchExp.Match(args.Parameters[0]);
				if (switchMatch.Success)
				{
					// A switch is in use, parse it
					string node = switchMatch.Groups["Switch"].Value;
					if (String.IsNullOrWhiteSpace(node))
						node = switchMatch.Groups["Word"].Value;

					args.Parameters.RemoveAt(0);
					switch (node)
					{
						case "c":
						case "temp":
						case "create-temporary":
							CreatePoll(args);
							break;
						case "C":
						case "create":
							CreatePoll(args, true);
							break;
						case "?":
						case "help":
							HelpPoll(args);
							break;
						default:
							args.Player.SendErrorMessage("Invalid switch! Available switches: -c (--temp) -C (--create) -? (--help)");
							return;
					}
				}
				else
					RunPoll(args);
			}
		}

		private static void CreatePoll(CommandArgs args, bool save = false)
		{
			if (args.Parameters.Count < 2)
				args.Player.SendErrorMessage($"Invalid syntax! Proper syntax: {TShockAPI.Commands.Specifier}poll -<c/C> <name> [time=x] <option1,option2,...>");
			else
			{
				string alias = args.Parameters[0];
				args.Parameters.RemoveAt(0);
				var regex = new Regex(@"(?:time=(?<Time>\d+)(?<Char>[dhms])? )?(?<Options>.+)");
				Match match = regex.Match(String.Join(" ", args.Parameters));
				int seconds = 0;
				if (!String.IsNullOrWhiteSpace(match.Groups["Time"].Value))
				{
					// add in timestring parser (and edit the regex so that it accepts more than 1 timechar
				}
			}
		}

		private static void HelpPoll(CommandArgs args)
		{

		}

		private static void RunPoll(CommandArgs args)
		{

		}

		public static void DoVote(CommandArgs args)
		{

		}
	}
}
