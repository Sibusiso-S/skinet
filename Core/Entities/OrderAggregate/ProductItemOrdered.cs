namespace Core.Entities.OrderAggregate
{
	public class ProductItemOrdered
	{
		public ProductItemOrdered(int productItemId, int productName, int productUrl)
		{
			this.ProductItemId = productItemId;
			this.ProductName = productName;
			this.ProductUrl = productUrl;

		}
		public int ProductItemId { get; set; }

		public int ProductName { get; set; }

		public int ProductUrl { get; set; }
	}
}