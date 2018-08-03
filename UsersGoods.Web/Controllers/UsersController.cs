using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsersGoods.Web.Resources;
using UsersGoods.Web.ViewModel.Users;

namespace UsersGoods.Web.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index(string search = null)
        {
            var list = new List<UserViewModel>
            {
                new UserViewModel { FirstName = "Иванов", SecondName = "Иван",    TotalAmount = 1024 },
                new UserViewModel { FirstName = "Петров", SecondName = "Пётр",   TotalAmount = 45.87m },
                new UserViewModel { FirstName = "Семёнов", SecondName = "Семён",   TotalAmount = 401.02m }
            };

            var model = new IndexViewModel
            {
                SearchString = search,
                Items = list
            };
            

            return View(model);
        }

        public ActionResult Card(long id, decimal? amountMin = null, decimal? amountMax = null)
        {
            var model = new CardViewModel
            {
                User = new UserViewModel { FirstName = "Иванов", SecondName = "Иван", TotalAmount = 1024 },
                Goods = new List<GoodViewModel>
                {
                    new GoodViewModel { Name = "Пианино", Amount = 458.04m },
                    new GoodViewModel { Name = "Скрипка", Amount = 1000.45m },
                    new GoodViewModel { Name = "Мотоцикл", Amount = 5202 },
                    new GoodViewModel { Name = "Клюшка", Amount = 23.01m }
                },
                AmountMax = amountMax,
                AmountMin = amountMin
            };
            return View(model);
        }
    }
}