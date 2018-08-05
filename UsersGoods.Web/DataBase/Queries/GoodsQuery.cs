using Dapper;
using System.Data;
using System.Threading.Tasks;
using UsersGoods.Web.Services.DTO;
using System.Collections.Generic;
using System;
using UsersGoods.Web.DataBase.Queries.Core;

namespace UsersGoods.Web.DataBase.Queries
{
	public class GoodsQueryParam
	{
		public decimal? AmountMin { get; set; }
		public decimal? AmountMax { get; set; }
	}

	public class GoodsQuery : BaseQueryWithCount<IEnumerable<GoodDTO>, long, GoodsQueryParam>
	{
		public GoodsQuery(IDbConnection connection): 
			base(connection)
		{
			
		}
		
		private QueryWhere GetQueryWhere(long userId, GoodsQueryParam param)
		{
			string where = "";
			var nativeParams = new Dictionary<string, object>() { { "userId", userId } };
			if (param.AmountMin.HasValue)
			{
				where += " and g.Amount >= CAST(@amountMin as money)";
				nativeParams["amountMin"] = param.AmountMin;
			}
			if (param.AmountMax.HasValue)
			{
				where += " and g.Amount <= CAST(@amountMax as money)";
				nativeParams["amountMax"] = param.AmountMax;
			}

			return new QueryWhere
			{
				Clause = where,
				Params = nativeParams
			};
		}

		public override async Task<IEnumerable<GoodDTO>> Get(long userId, GoodsQueryParam param)
		{
			string sql =  @"select distinct g.Name, g.Amount
							from PurchaseItems pi 
								inner join Goods g on pi.GoodId = g.Id
								inner join Purchases p on pi.PurchaseId = p.Id
							where p.UserId = @userId {0}
							order by g.Amount desc";

			var queryWhere = GetQueryWhere(userId, param);
			return await _connection.QueryAsync<GoodDTO>(String.Format(sql, queryWhere.Clause), queryWhere.Params);

		}

		public override async Task<int> GetCount(long userId, GoodsQueryParam param)
		{
			string sql = @"select count(distinct g.Id) Count
							from PurchaseItems pi 
								inner join Goods g on pi.GoodId = g.Id
								inner join Purchases p on pi.PurchaseId = p.Id
							where p.UserId = @userId {0}";

			var queryWhere = GetQueryWhere(userId, param);

			return await _connection.QueryFirstAsync<int>(String.Format(sql, queryWhere.Clause), queryWhere.Params);

		}
		public override async Task<int> GetTotalCount(long userId)
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