using Dapper;
using System.Data;
using System.Threading.Tasks;
using UsersGoods.Web.DataBase.Queries.Core;
using UsersGoods.Web.Services.DTO;

namespace UsersGoods.Web.DataBase.Queries
{
	public class UserQuery : BaseQuery<UserDTO, long>
	{
		
		public UserQuery(IDbConnection connection): 
			base(connection)
		{
			
		}

		public override async Task<UserDTO> Get(long userId)
		{
			string sql = @"select  u.Id, 
								   u.FirstName, 
								   u.SecondName, 
								   COALESCE(Sum(p.TotalAmount), CAST(0 as money)) TotalAmount 
							from Users u 
							 left join Purchases p on p.UserId = u.Id
                            where u.Id = @userId
                            group by u.Id, u.FirstName, u.SecondName";
			return await _connection.QueryFirstOrDefaultAsync<UserDTO>(sql, new { userId });

		}
	}
}