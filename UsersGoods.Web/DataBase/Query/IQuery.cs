using System.Threading.Tasks;

namespace UsersGoods.Web.DataBase.Query
{
	public interface IQuery<T>
	{
		Task<T> Get();
	}
}