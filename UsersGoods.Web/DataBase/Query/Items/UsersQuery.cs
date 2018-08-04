using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UsersGoods.Web.Services.DTO;

namespace UsersGoods.Web.DataBase.Query.Items
{
	public class UsersQuery: BaseQuery<IEnumerable<UserDTO>>
	{
		private readonly string _part1;
		private readonly string _part2;
		public UsersQuery(IDbConnection connection, string part1, string part2): 
			base(connection)
		{
			_part1 = part1;
			_part2 = part2;
		}

		public override async Task<IEnumerable<UserDTO>> Get()
		{
			string sql = @"select  u.Id, 
								   u.FirstName, 
								   u.SecondName, 
								   COALESCE(Sum(p.TotalAmount), CAST(0 as money)) TotalAmount 
							from Users u 
							 left join Purchases p on p.UserId = u.Id
                             {0}
							group by u.Id, u.FirstName, u.SecondName
							order by TotalAmount desc";

			string where = null;
			if (!String.IsNullOrWhiteSpace(_part1) && !String.IsNullOrWhiteSpace(_part2))
			{
				where = "where upper(u.FirstName) like @part1 and upper(u.SecondName) like @part2";
				sql = String.Format(sql, where);
				return await _connection.QueryAsync<UserDTO>(sql,
					new
					{
						part1 = _part1.ToUpperInvariant(),
						part2 = _part2.ToUpperInvariant()
					});
			}
			else if (!String.IsNullOrWhiteSpace(_part1))
			{
				where = "where upper(u.FirstName) like @part1 or upper(u.SecondName) like @part1";
				sql = String.Format(sql, where);
				return await _connection.QueryAsync<UserDTO>(sql,
					new
					{
						part1 = _part1.ToUpperInvariant()
					});
			}
			else
				return await _connection.QueryAsync<UserDTO>(String.Format(sql, where));

		}
	}
}