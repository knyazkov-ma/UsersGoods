using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersGoods.Web.ViewModel.Users
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public decimal TotalAmount { get; set; }
    }
}