using Dapper;
using System.Data;
using System.Threading.Tasks;
using UsersGoods.Web.DataBase.Queries.Core;

namespace UsersGoods.Web.DataBase.Queries
{
	public class GoodsTotalCountQuery : BaseQuery<int, long>
	{
		public GoodsTotalCountQuery(IDbConnection connection): 
			base(connection)
		{
						
		}

		public override async Task<int> Get(long userId)
		{
			string sql = @"select count(distinct g.Id) Count
							from PurchaseItems pi 
								inner join Goods g on pi.GoodId = g.Id
								inner join Purchases p on pi.PurchaseId = p.Id
							where p.UserId = @userId";

			return await _connection.QueryFirstAsync<int>(sql, new { userId });
		}
	}
}