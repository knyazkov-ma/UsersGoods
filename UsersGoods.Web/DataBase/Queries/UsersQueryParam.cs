using Dapper;
using System.Data;
using System.Threading.Tasks;
using UsersGoods.Web.Services.DTO;
using System.Collections.Generic;
using System;

namespace UsersGoods.Web.DataBase.Queries
{
	public class UsersQueryParam
	{
		public string Part1 { get; set; }
		public string Part2 { get; set; }
	}
}