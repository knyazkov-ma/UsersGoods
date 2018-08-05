namespace UsersGoods.Web.Services.DTO
{
	/// <summary>
	/// Товар
	/// </summary>
	public class GoodDTO
    {
		/// <summary>
		/// Наименование
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Стоимость
		/// </summary>
		public decimal Amount { get; set; }
	}
}