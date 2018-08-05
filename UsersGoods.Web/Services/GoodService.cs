using System.Collections.Generic;
using System.Threading.Tasks;
using UsersGoods.Web.DataBase.Queries;
using UsersGoods.Web.DataBase.Queries.Core;
using UsersGoods.Web.Services.DTO;
using UsersGoods.Web.Services.Interface;

namespace UsersGoods.Web.Services
{
	public class GoodService : IGoodService
    {
		
		private readonly IQueryWithCount<IEnumerable<GoodDTO>, long, GoodsQueryParam> _goodsQuery;
		private readonly IQuery<TopGoodDTO> _topGoodQuery;

		public GoodService(IQueryWithCount<IEnumerable<GoodDTO>, long, GoodsQueryParam> goodsQuery,
			IQuery<TopGoodDTO> topGoodQuery)
        {
			_goodsQuery = goodsQuery;
			_topGoodQuery = topGoodQuery;
		}

        public async Task<IEnumerable<GoodDTO>> GetGoods(long userId, decimal? amountMin = null, decimal? amountMax = null)
        {
            return await _goodsQuery.Get(userId, new GoodsQueryParam { AmountMin = amountMin, AmountMax = amountMax });
        }

		public async Task<int> GetGoodsCount(long userId, decimal? amountMin = null, decimal? amountMax = null)
		{
			return await _goodsQuery.GetCount(userId, new GoodsQueryParam { AmountMin = amountMin, AmountMax = amountMax });
		}
		public async Task<int> GetTotalGoodsCount(long userId)
		{
			return await _goodsQuery.GetTotalCount(userId);
		}

		public async Task<TopGoodDTO> GetTopGood()
        {
            return await _topGoodQuery.Get();
        }
    }
}