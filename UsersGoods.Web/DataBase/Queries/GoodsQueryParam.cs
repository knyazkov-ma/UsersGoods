namespace UsersGoods.Web.DataBase.Queries
{
	public class GoodsQueryParam
	{
		public long UserId { get; set; }
		public decimal? AmountMin { get; set; }
		public decimal? AmountMax { get; set; }
	}
}