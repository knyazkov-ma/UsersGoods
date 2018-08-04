using System.Data;
using UsersGoods.Web.DataBase.Query.Items;

namespace UsersGoods.Web.DataBase.Query
{
	public class QueryFactory : IQueryFactory
	{
		private readonly IDbConnection _connection;

		public QueryFactory(IDbConnection connection)
		{
			_connection = connection;
		}

		public UsersQuery GetUsersQuery(string part1, string part2)
		{
			return new UsersQuery(_connection, part1, part2);
		}

		public UserQuery GetUserQuery(long userId)
		{
			return new UserQuery(_connection, userId);
		}

		public TopGoodQuery GetTopGoodQuery()
		{
			return new TopGoodQuery(_connection);
		}

		public GoodsQuery GetGoodsQuery(long userId, decimal? amountMin, decimal? amountMax)
		{
			return new GoodsQuery(_connection, userId, amountMin, amountMax);
		}

	}
}