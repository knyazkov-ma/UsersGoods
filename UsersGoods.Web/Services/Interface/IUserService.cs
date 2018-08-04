using System.Collections.Generic;
using System.Threading.Tasks;
using UsersGoods.Web.Services.DTO;

namespace UsersGoods.Web.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsers(string searchString = null);

        Task<UserDTO> GetUser(long userId);
    }
}
