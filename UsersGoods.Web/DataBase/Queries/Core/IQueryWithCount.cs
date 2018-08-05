using System.Threading.Tasks;

namespace UsersGoods.Web.DataBase.Queries.Core
{
	public interface IQueryWithCount<TDto, TParam>
	{
		Task<TDto> Get(TParam param);
		Task<int> GetCount(TParam param);
		Task<int> GetTotalCount();
	}

	public interface IQueryWithCount<TDto, TkeyParam, TParam>
	{
		Task<TDto> Get(TkeyParam keyParam, TParam param);
		Task<int> GetCount(TkeyParam keyParam, TParam param);
		Task<int> GetTotalCount(TkeyParam keyParam);
	}

}