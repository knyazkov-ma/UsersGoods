using Dapper;
using System.Data;
using System.Threading.Tasks;
using UsersGoods.Web.Services.DTO;
using System.Collections.Generic;
using System;

namespace UsersGoods.Web.DataBase.Queries
{
	public class GoodsQueryParam
	{
		public long UserId { get; set; }
		public decimal? AmountMin { get; set; }
		public decimal? AmountMax { get; set; }
	}
}