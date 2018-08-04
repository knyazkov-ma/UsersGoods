using UsersGoods.Web.DataBase.Query.Items;

namespace UsersGoods.Web.DataBase.Query
{
	public interface IQueryFactory
	{
		UsersQuery GetUsersQuery(string part1, string part2);
		UserQuery GetUserQuery(long userId);
		TopGoodQuery GetTopGoodQuery();
		GoodsQuery GetGoodsQuery(long userId, decimal? amountMin, decimal? amountMax);
	}
}