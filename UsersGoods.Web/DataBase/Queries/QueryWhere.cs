using System.Collections.Generic;

namespace UsersGoods.Web.DataBase.Queries
{
	public class QueryWhere
	{
		public string Clause { get; set; }
		public IDictionary<string, object> Params { get; set; }
	}
}