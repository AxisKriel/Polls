using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polls.DB
{
	public class Options
	{
		private List<long> _options = new List<long>();

		public Options(long values)
		{

		}

		public Options(long[] values)
		{
			_options = new List<long>(values);
		}

		public static implicit operator Options(long[] values)
		{
			return new Options(values);
		}

		public long[] ToArray()
		{
			return _options.ToArray();
		}

		public override string ToString()
		{
			return String.Join(",", _options);
		}
	}
}
