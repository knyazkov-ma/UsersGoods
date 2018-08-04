using System.Collections.Generic;
using System.Threading.Tasks;
using UsersGoods.Web.DataBase.Query;
using UsersGoods.Web.Services.DTO;
using UsersGoods.Web.Services.Interface;

namespace UsersGoods.Web.Services
{
	public class GoodService : IGoodService
    {
        private readonly IQueryFactory _queryFactory;

        public GoodService(IQueryFactory queryFactory)
        {
			_queryFactory = queryFactory;
        }

        public async Task<IEnumerable<GoodDTO>> GetGoods(long userId, decimal? amountMin = null, decimal? amountMax = null)
        {
            return await _queryFactory.GetGoodsQuery(userId, amountMin, amountMax).Get();
        }

        public async Task<TopGoodDTO> GetTopGood()
        {
            return await _queryFactory.GetTopGoodQuery().Get();
        }
    }
}