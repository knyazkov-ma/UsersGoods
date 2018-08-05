using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UsersGoods.Web.DataBase.Queries.Core;
using UsersGoods.Web.Services.DTO;

namespace UsersGoods.Web.DataBase.Queries
{
	public class UsersCountQuery : BaseQuery<int, UsersQueryParam>
	{
		public UsersCountQuery(IDbConnection connection): 
			base(connection)
		{
			
		}

		public override async Task<int> Get(UsersQueryParam param)
		{
			string sql = @"select count(u.Id) Count from Users u {0}";

			string where = null;
			if (!String.IsNullOrWhiteSpace(param.Part1) && !String.IsNullOrWhiteSpace(param.Part2))
			{
				where = "where upper(u.FirstName) like @part1 and upper(u.SecondName) like @part2";
				sql = String.Format(sql, where);
				return await _connection.QueryFirstAsync<int>(sql,
					new
					{
						part1 = param.Part1.ToUpperInvariant(),
						part2 = param.Part2.ToUpperInvariant()
					});
			}
			else if (!String.IsNullOrWhiteSpace(param.Part1))
			{
				where = "where upper(u.FirstName) like @part1 or upper(u.SecondName) like @part1";
				sql = String.Format(sql, where);
				return await _connection.QueryFirstAsync<int>(sql,
					new
					{
						part1 = param.Part1.ToUpperInvariant()
					});
			}
			else
				return await _connection.QueryFirstAsync<int>(String.Format(sql, where));

		}
	}
}