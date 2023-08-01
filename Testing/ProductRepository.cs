using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using Dapper;
using Testing.Models;

namespace Testing
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("Select * FROM PRODUCTS WHERE ProductID = @prodID", new { prodID = id });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("Select * FROM PRODUCTS;");
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE PRODUCTS SET Name = @name, Price = @price, WHERE ProductID = @id", 
                new {name = product.Name, price = product.Price, id = product.ProductID});
        }

        public void InsertProduct(Product product) 
        {
            _conn.Execute("INSERT INTO PRODUCTS (Name, Price, CategoryID) values (@name, @price, @categoryid)", 
                new {name = product.Name, price = product.Price, categoryid = product.CategoryID});
        }
        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM CATEGORIES;");
        }
        public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;
            return product;
        }
    }
}
