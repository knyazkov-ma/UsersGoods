namespace UsersGoods.Web.Services.DTO
{
	/// <summary>
	/// Наиболее часто покупаемый товар
	/// </summary>
	public class TopGoodDTO
    {
		/// <summary>
		/// Наименование
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Количество покупок
		/// </summary>
		public int PurchaseCount { get; set; }
    }
}