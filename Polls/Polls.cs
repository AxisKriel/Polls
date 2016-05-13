using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariaApi.Server;
using System.Reflection;
using Terraria;

namespace Polls
{
	[ApiVersion(1, 22)]
	public class Polls : TerrariaPlugin
	{
		public override string Author
		{
			get { return "Enerdy"; }
		}

		public override string Description
		{
			get { return "Create and run polls, for Science"; }
		}

		public override string Name
		{
			get { return "Polls"; }
		}

		public override Version Version
		{
			get { return Assembly.GetExecutingAssembly().GetName().Version; }
		}

		public Polls(Main game) : base(game)
		{

		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{

			}
		}

		public override void Initialize()
		{
			
		}
	}
}
