using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsersGoods.Web.Resources;

namespace UsersGoods.Web.Controllers
{
    public class GoodsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
    }
}