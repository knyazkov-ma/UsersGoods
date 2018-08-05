using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersGoods.Web.DataBase.Queries
{
	public class QueryWhere
	{
		public string Clause { get; set; }
		public IDictionary<string, object> Params { get; set; }
	}
}