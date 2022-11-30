namespace Core.Entities.OrderAggregate
{
	public class ProductItemOrdered
	{
		public ProductItemOrdered()
		{
		}

		public ProductItemOrdered(int productItemId, string productName, string productUrl)
		{
			this.ProductItemId = productItemId;
			this.ProductName = productName;
			this.ProductUrl = productUrl;

		}
		public int ProductItemId { get; set; }

		public string ProductName { get; set; }

		public string ProductUrl { get; set; }
	}
}