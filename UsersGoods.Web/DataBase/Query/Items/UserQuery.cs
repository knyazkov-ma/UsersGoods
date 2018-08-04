using Dapper;
using System.Data;
using System.Threading.Tasks;
using UsersGoods.Web.Services.DTO;

namespace UsersGoods.Web.DataBase.Query.Items
{
	public class UserQuery : BaseQuery<UserDTO>
	{
		private readonly long _userId;
		public UserQuery(IDbConnection connection, long userId): 
			base(connection)
		{
			_userId = userId;
		}

		public override async Task<UserDTO> Get()
		{
			string sql = @"select  u.Id, 
								   u.FirstName, 
								   u.SecondName, 
								   COALESCE(Sum(p.TotalAmount), CAST(0 as money)) TotalAmount 
							from Users u 
							 left join Purchases p on p.UserId = u.Id
                            where u.Id = @userId
                            group by u.Id, u.FirstName, u.SecondName";
			return await _connection.QueryFirstAsync<UserDTO>(sql,
					new
					{
						userId = _userId
					});

		}
	}
}