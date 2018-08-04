using System.Data;
using System.Threading.Tasks;

namespace UsersGoods.Web.DataBase.Query
{
	public abstract class BaseQuery<T>: IQuery<T>
	{
		protected readonly IDbConnection _connection;

		public BaseQuery(IDbConnection connection)
		{
			_connection = connection;
		}

		public abstract Task<T> Get();
	}
}