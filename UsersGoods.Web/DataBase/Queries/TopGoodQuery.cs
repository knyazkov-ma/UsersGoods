using Dapper;
using System.Data;
using System.Threading.Tasks;
using UsersGoods.Web.DataBase.Queries.Core;
using UsersGoods.Web.Services.DTO;

namespace UsersGoods.Web.DataBase.Queries
{
	public class TopGoodQuery : BaseQuery<TopGoodDTO>
	{
		
		public TopGoodQuery(IDbConnection connection): 
			base(connection)
		{
			
		}

		public override async Task<TopGoodDTO> Get()
		{
			string sql = @"select  g.Name, 
								   t.PurchaseCount 
							from TopGoods t 
							  inner join Goods g on t.GoodId = g.Id
							order by t.PurchaseCount desc
							limit 1";
			return await _connection.QueryFirstOrDefaultAsync<TopGoodDTO>(sql);			
		}
	}
}