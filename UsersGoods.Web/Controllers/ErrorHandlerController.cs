using System.Web.Mvc;

namespace UsersGoods.Web.Controllers
{
	public class ErrorHandlerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult NotFound()
		{
			return View();
		}
		

	}
}