using System.Collections.Generic;

namespace UsersGoods.Web.ViewModel.Users
{
    public class IndexViewModel
    {
        public IEnumerable<UserViewModel> Items { get; set; }
        public string SearchString { get; set; }

		public int ItemsTotalCount { get; set; }
		public int ItemsCount { get; set; }
		public bool IsFiltered
		{
			get
			{
				return !string.IsNullOrWhiteSpace(SearchString);
			}
		}
    }
}