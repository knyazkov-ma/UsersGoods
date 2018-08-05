using Dapper;
using System.Data;
using System.Threading.Tasks;
using UsersGoods.Web.DataBase.Queries.Core;

namespace UsersGoods.Web.DataBase.Queries
{
	public class UsersTotalCountQuery : BaseQuery<int>
	{
		public UsersTotalCountQuery(IDbConnection connection): 
			base(connection)
		{
			
		}

		public override async Task<int> Get()
		{
			string sql = @"select count(u.Id) Count from Users u";

			return await _connection.QueryFirstAsync<int>(sql);
		}
	}
}