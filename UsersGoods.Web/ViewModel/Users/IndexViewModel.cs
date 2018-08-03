using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersGoods.Web.ViewModel.Users
{
    public class IndexViewModel
    {
        public IEnumerable<UserViewModel> Items { get; set; }
        public string SearchString { get; set; }
    }
}