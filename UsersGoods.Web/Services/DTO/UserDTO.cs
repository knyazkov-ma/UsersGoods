namespace UsersGoods.Web.Services.DTO
{
	/// <summary>
	/// Пользователь
	/// </summary>
	public class UserDTO
    {
		/// <summary>
		/// PK
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Имя
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия
		/// </summary>
		public string SecondName { get; set; }

		/// <summary>
		/// Всего куплено товаров на сумму
		/// </summary>
		public decimal TotalAmount { get; set; }
    }
}