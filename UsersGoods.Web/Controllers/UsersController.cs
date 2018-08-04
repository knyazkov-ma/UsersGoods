using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using UsersGoods.Web.Services.Interface;
using UsersGoods.Web.ViewModel.Users;

namespace UsersGoods.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

		private async Task<IndexViewModel> getModel(string search = null)
		{
			var list = Mapper.Map<IEnumerable<UserViewModel>>(await _userService.GetUsers(search));
			var model = new IndexViewModel
			{
				SearchString = search,
				Items = list
			};
			return model;
		}

		public async Task<ActionResult> Index(string search = null)
        {
            return View(await getModel(search));
        }

		public async Task<ActionResult> Reset()
		{
			return View(await getModel());
		}
		
    }
}