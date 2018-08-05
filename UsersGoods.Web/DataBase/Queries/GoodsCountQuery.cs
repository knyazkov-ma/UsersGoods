using Dapper;
using System.Data;
using System.Threading.Tasks;
using UsersGoods.Web.Services.DTO;
using System.Collections.Generic;
using System;
using UsersGoods.Web.DataBase.Queries.Core;

namespace UsersGoods.Web.DataBase.Queries
{
	public class GoodsCountQuery : BaseQuery<int, GoodsQueryParam>
	{
		
		public GoodsCountQuery(IDbConnection connection): 
			base(connection)
		{
			
		}

		public override async Task<int> Get(GoodsQueryParam param)
		{
			string sql =  @"select count(distinct g.Id) Count
							from PurchaseItems pi 
								inner join Goods g on pi.GoodId = g.Id
								inner join Purchases p on pi.PurchaseId = p.Id
							where p.UserId = @userId {0}";

			string where = "";
			IDictionary<string, object> nativeParams = new Dictionary<string, object>() { { "userId", param.UserId } };
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

			return await _connection.QueryFirstAsync<int>(String.Format(sql, where), nativeParams);

		}
	}
}