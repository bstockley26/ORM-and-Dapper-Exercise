using System;
namespace ORM_Dapper
{
	public interface IProductRepo
	{
		public IEnumerable<Product> GetAllPRoducts();
		void CreateProduct(string name, double price, int categoryID, bool onSale,int stockLevel);
	}
}

