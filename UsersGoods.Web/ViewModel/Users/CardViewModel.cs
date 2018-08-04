using System.Collections.Generic;

namespace UsersGoods.Web.ViewModel.Users
{
    public class CardViewModel
    {
        public UserViewModel User { get; set; }
        public IEnumerable<GoodViewModel> Goods { get; set; }
        public decimal? AmountMin { get; set; }
        public decimal? AmountMax { get; set; }        
    }
}