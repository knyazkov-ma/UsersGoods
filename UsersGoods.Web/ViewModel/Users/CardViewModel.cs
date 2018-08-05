using System.Collections.Generic;

namespace UsersGoods.Web.ViewModel.Users
{
    public class CardViewModel
    {
        public UserViewModel User { get; set; }
        public IEnumerable<GoodViewModel> Goods { get; set; }
        public decimal? AmountMin { get; set; }
        public decimal? AmountMax { get; set; }

		public int GoodsTotalCount { get; set; }
		public int GoodsCount { get; set; }

		public bool IsFiltered
		{
			get
			{
				return AmountMin.HasValue || AmountMax.HasValue;
			}
		}
	}
}