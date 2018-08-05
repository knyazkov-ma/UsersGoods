using System.Data;
using System.Threading.Tasks;

namespace UsersGoods.Web.DataBase.Queries.Core
{
	public abstract class BaseQuery<TDto>: IQuery<TDto>
	{
		protected readonly IDbConnection _connection;

		public BaseQuery(IDbConnection connection)
		{
			_connection = connection;
		}

		public abstract Task<TDto> Get();
	}

	public abstract class BaseQuery<TDto, TParam> : IQuery<TDto, TParam>
	{
		protected readonly IDbConnection _connection;

		public BaseQuery(IDbConnection connection)
		{
			_connection = connection;
		}

		public abstract Task<TDto> Get(TParam param);
	}
}