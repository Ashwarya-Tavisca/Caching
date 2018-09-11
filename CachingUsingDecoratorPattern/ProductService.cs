using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingUsingDecoratorPattern
{
    class ProductService : IProductService
    {
        public Product GetProductById(int id)
        {
            IRepository productRepo = new SqlDatabase();
            Console.WriteLine("Data Retrieved from Sql");
            return productRepo.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            IRepository productRepo = new SqlDatabase();
            return productRepo.GetAllProducts();
        }
    }
}
