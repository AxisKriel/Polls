using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using TShockAPI.DB;
using TShockAPI;
using Mono.Data.Sqlite;

namespace Polls.DB
{
	public class PollManager
	{
		private IDbConnection db;

		public PollManager(IDbConnection db)
		{
			this.db = db;

			IQueryBuilder builder = db.GetSqlType() == SqlType.Mysql
				? (IQueryBuilder)new MysqlQueryCreator()
				: new SqliteQueryCreator();

			SqlTableCreator sql = new SqlTableCreator(db, builder);

			SqlTable poll = new SqlTable("poll",
				new SqlColumn("ID", MySqlDbType.Int32) { AutoIncrement = true, Primary = true },
				new SqlColumn("Alias", MySqlDbType.VarChar) { Length = 15, Unique = true },
				new SqlColumn("Description", MySqlDbType.Text),
				new SqlColumn("Time", MySqlDbType.Int32),
				new SqlColumn("Type", MySqlDbType.Byte),
				new SqlColumn("Log", MySqlDbType.Byte));

			SqlTable poll_options = new SqlTable("poll_options",
				new SqlColumn("ID", MySqlDbType.Int32) { AutoIncrement = true, Primary = true },
				new SqlColumn("Name", MySqlDbType.VarChar) { Length = 20 },
				new SqlColumn("Poll_ID", MySqlDbType.Int32));

			SqlTable poll_data = new SqlTable("poll_data",
				new SqlColumn("ID", MySqlDbType.Int32) { AutoIncrement = true, Primary = true },
				new SqlColumn("Poll_ID", MySqlDbType.Int32),
				new SqlColumn("Date", MySqlDbType.Int64),
				new SqlColumn("Option", MySqlDbType.VarChar) { Length = 20 },
				new SqlColumn("Value", MySqlDbType.Int32));
			
			if (sql.EnsureTableStructure(poll))
				TShock.Log.ConsoleInfo("Polls: created table 'poll'.");
			if (sql.EnsureTableStructure(poll_options))
				TShock.Log.ConsoleInfo("Polls: created table 'poll_options'.");
			if (sql.EnsureTableStructure(poll_data))
				TShock.Log.ConsoleInfo("Polls: created table 'poll_data'.");
		}
	}
}
