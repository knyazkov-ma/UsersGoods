﻿using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using UsersGoods.Web.Services.Interface;
using UsersGoods.Web.ViewModel.Users;

namespace UsersGoods.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IGoodService _goodService;
        public UserController(IUserService userService, IGoodService goodService)
        {
            _userService = userService;
            _goodService = goodService;
        }

		public async Task<ActionResult> Index(long id, decimal? amountMin = null, decimal? amountMax = null)
        {
			var user = await _userService.GetUser(id);
			if (user == null)
				return View("NotFound");

			var model = new CardViewModel
            {
                User = Mapper.Map<UserViewModel>(user),
                Goods = Mapper.Map<IEnumerable<GoodViewModel>>(await _goodService.GetGoods(id, amountMin, amountMax)),
                AmountMax = amountMax,
                AmountMin = amountMin,
				GoodsCount = await _goodService.GetGoodsCount(id, amountMin, amountMax),
				GoodsTotalCount = await _goodService.GetTotalGoodsCount(id)
			};
            return View(model);
        }
    }
}