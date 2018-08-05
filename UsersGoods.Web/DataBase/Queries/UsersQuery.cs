using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UsersGoods.Web.DataBase.Queries.Core;
using UsersGoods.Web.Services.DTO;

namespace UsersGoods.Web.DataBase.Queries
{
	public class UsersQueryParam
	{
		public string Part1 { get; set; }
		public string Part2 { get; set; }
	}

	public class UsersQuery: BaseQueryWithCount<IEnumerable<UserDTO>, UsersQueryParam>
	{
		
		public UsersQuery(IDbConnection connection): 
			base(connection)
		{
			
		}

		private QueryWhere GetQueryWhere(UsersQueryParam param)
		{
			IDictionary<string, object> nativeParams = new Dictionary<string, object>();
			string where = null;
			if (!String.IsNullOrWhiteSpace(param.Part1) && !String.IsNullOrWhiteSpace(param.Part2))
			{
				where = "where upper(u.FirstName) like CONCAT(@part1,'%') and upper(u.SecondName) like CONCAT(@part2,'%')";
				nativeParams["part1"] = param.Part1.ToUpperInvariant();
				nativeParams["part2"] = param.Part2.ToUpperInvariant();
			}
			else if (!String.IsNullOrWhiteSpace(param.Part1))
			{
				where = "where upper(u.FirstName) like CONCAT(@part1,'%') or upper(u.SecondName) like CONCAT(@part1,'%')";
				nativeParams["part1"] = param.Part1.ToUpperInvariant();
			}

			return new QueryWhere
			{
				Clause = where,
				Params = nativeParams
			};
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

			var queryWhere = GetQueryWhere(param);
			
			return await _connection.QueryAsync<UserDTO>(String.Format(sql, queryWhere.Clause), queryWhere.Params);

		}

		public override async Task<int> GetCount(UsersQueryParam param)
		{
			string sql = @"select count(u.Id) Count from Users u {0}";

			var queryWhere = GetQueryWhere(param);

			return await _connection.QueryFirstAsync<int>(String.Format(sql, queryWhere.Clause), queryWhere.Params);

		}

		public override async Task<int> GetTotalCount()
		{
			string sql = @"select count(u.Id) Count from Users u";

			return await _connection.QueryFirstAsync<int>(sql);
		}
	}
}