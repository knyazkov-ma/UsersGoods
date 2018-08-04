using System.Collections.Generic;

namespace UsersGoods.Web.ViewModel.Users
{
    public class IndexViewModel
    {
        public IEnumerable<UserViewModel> Items { get; set; }
        public string SearchString { get; set; }
    }
}