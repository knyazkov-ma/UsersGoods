using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UsersGoods.Web.DataBase.Queries.Core;
using UsersGoods.Web.Services.DTO;

namespace UsersGoods.Web.DataBase.Queries
{
	public class UsersQuery: BaseQuery<IEnumerable<UserDTO>, UsersQueryParam>
	{
		
		public UsersQuery(IDbConnection connection): 
			base(connection)
		{
			
		}

		public override async Task<IEnumerable<UserDTO>> Get(UsersQueryParam param)
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
			if (!String.IsNullOrWhiteSpace(param.Part1) && !String.IsNullOrWhiteSpace(param.Part2))
			{
				where = "where upper(u.FirstName) like CONCAT(@part1,'%') and upper(u.SecondName) like CONCAT(@part2,'%')";
				sql = String.Format(sql, where);
				return await _connection.QueryAsync<UserDTO>(sql,
					new
					{
						part1 = param.Part1.ToUpperInvariant(),
						part2 = param.Part2.ToUpperInvariant()
					});
			}
			else if (!String.IsNullOrWhiteSpace(param.Part1))
			{
				where = "where upper(u.FirstName) like CONCAT(@part1,'%') or upper(u.SecondName) like CONCAT(@part1,'%')";
				sql = String.Format(sql, where);
				return await _connection.QueryAsync<UserDTO>(sql,
					new
					{
						part1 = param.Part1.ToUpperInvariant()
					});
			}
			else
				return await _connection.QueryAsync<UserDTO>(String.Format(sql, where));

		}
	}
}