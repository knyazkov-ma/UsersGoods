using System.Collections.Generic;
using System.Threading.Tasks;
using UsersGoods.Web.DataBase.Query;
using UsersGoods.Web.Services.DTO;
using UsersGoods.Web.Services.Interface;

namespace UsersGoods.Web.Services
{
	public class UserService: IUserService
    {
        private readonly IQueryFactory _queryFactory;
		public UserService(IQueryFactory queryFactory)
        {
			_queryFactory = queryFactory;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers(string searchString = null)
        {
			string part1 = null;
			string part2 = null;
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                var parts = searchString.Split(' ');
				if (parts.Length == 1)
					part1 = parts[0];
				else if(parts.Length >= 2)
				{
					part1 = parts[0];
					part2 = parts[1];
				}
            }

			return await _queryFactory.GetUsersQuery(part1, part2).Get();
		}

        public async Task<UserDTO> GetUser(long userId)
        {
            return await _queryFactory.GetUserQuery(userId).Get();
        }
    }
}