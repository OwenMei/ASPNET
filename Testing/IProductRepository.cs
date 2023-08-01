using Testing.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace Testing
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        public void UpdateProduct(Product product);
        public void InsertProduct(Product product);
        public IEnumerable<Category> GetCategories();
        public Product AssignCategory();
        public void DeleteProduct(Product product);
    }
}
