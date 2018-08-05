﻿using System.Collections.Generic;
using System.Threading.Tasks;
using UsersGoods.Web.DataBase.Queries;
using UsersGoods.Web.DataBase.Queries.Core;
using UsersGoods.Web.Services.DTO;
using UsersGoods.Web.Services.Interface;

namespace UsersGoods.Web.Services
{
	public class UserService: IUserService
    {
		private readonly IQuery<IEnumerable<UserDTO>, UsersQueryParam> _usersQuery;
		private readonly IQuery<int, UsersQueryParam> _usersCountQuery;
		private readonly IQuery<int> _usersTotalCountQuery;
		private readonly IQuery<UserDTO, long> _userQuery;
		public UserService(IQuery<IEnumerable<UserDTO>, UsersQueryParam> usersQuery,
			IQuery<int, UsersQueryParam> usersCountQuery,
			IQuery<int> usersTotalCountQuery,
			IQuery<UserDTO, long> userQuery)
        {
			_usersQuery = usersQuery;
			_usersCountQuery = usersCountQuery;
			_usersTotalCountQuery = usersTotalCountQuery;
			_userQuery = userQuery;
		}

		private string[] GetPartsFromString(string searchString)
		{
			var result = new string[2] { null, null };

			if (!string.IsNullOrWhiteSpace(searchString))
			{
				var parts = searchString.Split(' ');
				if (parts.Length == 1)
					result[0] = parts[0];
				else if (parts.Length >= 2)
				{
					result[0] = parts[0];
					result[1] = parts[1];
				}
			}

			if (result[0] != null && result[0].Length < 3)
				result[0] = null;
			if (result[1] != null && result[1].Length < 3)
				result[1] = null;

			return result;
		}

		public async Task<IEnumerable<UserDTO>> GetUsers(string searchString)
        {
			
			var parts = GetPartsFromString(searchString);

			return await _usersQuery.Get(new UsersQueryParam { Part1 = parts[0], Part2 = parts[1] });
		}

		public async Task<int> GetUsersCount(string searchString = null)
		{
			var parts = GetPartsFromString(searchString);

			return await _usersCountQuery.Get(new UsersQueryParam { Part1 = parts[0], Part2 = parts[1] });
		}
		public async Task<int> GetTotalUsersCount()
		{
			return await _usersTotalCountQuery.Get();
		}

		public async Task<UserDTO> GetUser(long userId)
        {
            return await _userQuery.Get(userId);
        }
    }
}