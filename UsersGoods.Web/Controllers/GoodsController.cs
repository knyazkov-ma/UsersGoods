using AutoMapper;
using System.Threading.Tasks;
using System.Web.Mvc;
using UsersGoods.Web.Services.DTO;
using UsersGoods.Web.Services.Interface;

namespace UsersGoods.Web.Controllers
{
    public class GoodsController : Controller
    {
        private readonly IGoodService _goodService;

        public GoodsController(IGoodService goodService)
        {
            _goodService = goodService;
        }

        public async Task<ActionResult> Index()
        {
            var topGoodDto = await _goodService.GetTopGood();
			if (topGoodDto == null)
				topGoodDto = new TopGoodDTO();

			var model = Mapper.Map<ViewModel.Goods.TopGoodViewModel>(topGoodDto);
            return View(model);
        }
        
    }
}