using System.Data;
using System.Threading.Tasks;

namespace UsersGoods.Web.DataBase.Queries.Core
{
	public abstract class BaseQueryWithCount<TDto, TParam> : IQueryWithCount<TDto, TParam>
	{
		protected readonly IDbConnection _connection;

		public BaseQueryWithCount(IDbConnection connection)
		{
			_connection = connection;
		}

		public abstract Task<TDto> Get(TParam param);
		public abstract Task<int> GetCount(TParam param);
		public abstract Task<int> GetTotalCount();
	}

	public abstract class BaseQueryWithCount<TDto, TkeyParam, TParam> : IQueryWithCount<TDto, TkeyParam, TParam>
	{
		protected readonly IDbConnection _connection;

		public BaseQueryWithCount(IDbConnection connection)
		{
			_connection = connection;
		}

		public abstract Task<TDto> Get(TkeyParam keyParam, TParam param);
		public abstract Task<int> GetCount(TkeyParam keyParam, TParam param);
		public abstract Task<int> GetTotalCount(TkeyParam keyParam);
	}
}