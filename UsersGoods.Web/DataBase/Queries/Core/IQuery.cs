using System.Threading.Tasks;

namespace UsersGoods.Web.DataBase.Queries.Core
{
	public interface IQuery<TDto>
	{
		Task<TDto> Get();
	}

	public interface IQuery<TDto, TParam>
	{
		Task<TDto> Get(TParam param);
	}	

}