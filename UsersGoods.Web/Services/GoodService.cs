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
		
		private readonly IQuery<IEnumerable<GoodDTO>, GoodsQueryParam> _goodsQuery;
		private readonly IQuery<int, GoodsQueryParam> _goodsCountQuery;
		private readonly IQuery<int, long> _goodsTotalCountQuery;
		private readonly IQuery<TopGoodDTO> _topGoodQuery;

		public GoodService(IQuery<IEnumerable<GoodDTO>, GoodsQueryParam> goodsQuery,
			IQuery<int, GoodsQueryParam> goodsCountQuery,
			IQuery<int, long> goodsTotalCountQuery,
			IQuery<TopGoodDTO> topGoodQuery)
        {
			_goodsQuery = goodsQuery;
			_goodsCountQuery = goodsCountQuery;
			_goodsTotalCountQuery = goodsTotalCountQuery;
			_topGoodQuery = topGoodQuery;
		}

        public async Task<IEnumerable<GoodDTO>> GetGoods(long userId, decimal? amountMin = null, decimal? amountMax = null)
        {
            return await _goodsQuery.Get(new GoodsQueryParam { UserId = userId, AmountMin = amountMin, AmountMax = amountMax });
        }

		public async Task<int> GetGoodsCount(long userId, decimal? amountMin = null, decimal? amountMax = null)
		{
			return await _goodsCountQuery.Get(new GoodsQueryParam { UserId = userId, AmountMin = amountMin, AmountMax = amountMax });
		}
		public async Task<int> GetTotalGoodsCount(long userId)
		{
			return await _goodsTotalCountQuery.Get(userId);
		}

		public async Task<TopGoodDTO> GetTopGood()
        {
            return await _topGoodQuery.Get();
        }
    }
}