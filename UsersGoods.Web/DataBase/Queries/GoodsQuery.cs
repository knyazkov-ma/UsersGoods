using Dapper;
using System.Data;
using System.Threading.Tasks;
using UsersGoods.Web.Services.DTO;
using System.Collections.Generic;
using System;
using UsersGoods.Web.DataBase.Queries.Core;

namespace UsersGoods.Web.DataBase.Queries
{
	
	public class GoodsQuery : BaseQuery<IEnumerable<GoodDTO>, GoodsQueryParam>
	{
		public GoodsQuery(IDbConnection connection): 
			base(connection)
		{
			
		}

		public override async Task<IEnumerable<GoodDTO>> Get(GoodsQueryParam param)
		{
			string sql =  @"select distinct g.Name, g.Amount
							from PurchaseItems pi 
								inner join Goods g on pi.GoodId = g.Id
								inner join Purchases p on pi.PurchaseId = p.Id
							where p.UserId = @userId {0}
							order by g.Amount desc";

			string where = "";
			IDictionary<string, object> nativeParams = new Dictionary<string, object>() { { "userId", param.UserId }  };
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

			return await _connection.QueryAsync<GoodDTO>(String.Format(sql, where), nativeParams);

		}
	}
}