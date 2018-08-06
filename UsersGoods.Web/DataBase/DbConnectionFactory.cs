using Npgsql;
using System;
using System.Data;
using System.Web;

namespace UsersGoods.Web.DataBase
{
	public class DbConnectionFactory
	{
		private const string DATABASE_CONTEXT_KEY = "UsersGoods.Context.Database";

		#region DbConnectionFactory
		private static Lazy<DbConnectionFactory> instance =
		  new Lazy<DbConnectionFactory>(() =>
		  {
			  var instance = new DbConnectionFactory();
			  return instance;
		  });

		public static DbConnectionFactory Instatce => instance.Value;
		#endregion

		public IDbConnection GetCurrent(string connectionString)
		{
			if (!HttpContext.Current.Items.Contains(DATABASE_CONTEXT_KEY))
			{
				var dbConnection = new NpgsqlConnection(connectionString);
				HttpContext.Current.Items.Add(DATABASE_CONTEXT_KEY, dbConnection);
			}

			return HttpContext.Current.Items[DATABASE_CONTEXT_KEY] as IDbConnection;
		}
		
	}
}