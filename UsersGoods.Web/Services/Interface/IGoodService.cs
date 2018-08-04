using System.Collections.Generic;
using System.Threading.Tasks;
using UsersGoods.Web.Services.DTO;

namespace UsersGoods.Web.Services.Interface
{
    public interface IGoodService
    {
        Task<IEnumerable<GoodDTO>> GetGoods(long userId, decimal? amountMin = null, decimal? amountMax = null);
        Task<TopGoodDTO> GetTopGood();
    }
}
