using Dapper;
using System.Data;
using System.Threading.Tasks;
using UsersGoods.Web.Services.DTO;
using System.Collections.Generic;
using System;

namespace UsersGoods.Web.DataBase.Query.Items
{
	public class GoodsQuery : BaseQuery<IEnumerable<GoodDTO>>
	{
		private readonly long _userId;
		private readonly decimal? _amountMin; 
		private readonly decimal? _amountMax;

		public GoodsQuery(IDbConnection connection, long userId, decimal? amountMin, decimal? amountMax): 
			base(connection)
		{
			_userId = userId;
			_amountMin = amountMin;
			_amountMax = amountMax;
		}

		public override async Task<IEnumerable<GoodDTO>> Get()
		{
			string sql =  @"select distinct g.Name, g.Amount
							from PurchaseItems pi 
								inner join Goods g on pi.GoodId = g.Id
								inner join Purchases p on pi.PurchaseId = p.Id
							where p.UserId = @userId {0}
							order by g.Amount desc";

			string where = "";
			IDictionary<string, object> param = new Dictionary<string, object>();
			if (_amountMin.HasValue)
			{
				where += " and g.Amount >= CAST(@amountMin as money)";
				param["amountMin"] = _amountMin;
			}
			if (_amountMax.HasValue)
			{
				where += " and g.Amount <= CAST(@amountMax as money)";
				param["amountMax"] = _amountMax;
			}

			return await _connection.QueryAsync<GoodDTO>(String.Format(sql, where), param);

		}
	}
}