using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polls.DB
{
	public enum PollType : byte
	{
		Single = 0,
		Multiple = 1
	}

	public class Poll
	{
		public int ID { get; set; }

		public string Alias { get; set; }

		public string Description { get; set; }

		public bool Log { get; set; }

		public Dictionary<string, int> Options { get; set; }

		public int Time { get; set; }

		public PollType Type { get; set; }

		public Poll()
		{
			Description = "";
			Options = new Dictionary<string, int>();
		}

		public Poll(string alias, string[] options, int time = 0) : this()
		{
			Alias = alias;
			for (int i = 0; i < options.Length - 1; i++)
			{
				Options.Add(options[i], 0);
			}
			Time = time;
		}

		public Poll(string alias, Dictionary<string, int> options, int time = 0) : this()
		{
			Alias = alias;
			Options = options;
			Time = time;
		}

		/// <summary>
		/// Database constructor
		/// </summary>
		public Poll(int id, string alias, string description, Dictionary<string, int> options, int time, byte type, byte log)
		{
			ID = id;
			Alias = alias;
			Description = description;
			Options = options;
			Time = time;
			Type = (PollType)type;
			Log = log == 1;
		}
	}
}
