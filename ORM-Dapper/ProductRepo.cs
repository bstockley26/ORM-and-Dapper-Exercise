using System;
using Dapper;

namespace ORM_Dapper
{
	public class ProductRepo : IProductRepo
	{
        private readonly System.Data.IDbConnection _conn;

        public ProductRepo(System.Data.IDbConnection conn)
        {
            _conn = conn;
        }

        public void CreateProduct(string name, double price, int categoryID, bool onSale,int stockLevel)
        {
            _conn.Execute("INSERT INTO products (Name, Price,CategoryID, OnSale,StockLevel) VALUES (@name, @price, @categoryID,@onSale, @stockLevel)", new { name, price, categoryID,onSale,stockLevel });
        }

        public IEnumerable<Product> GetAllPRoducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }

        
    }
}

