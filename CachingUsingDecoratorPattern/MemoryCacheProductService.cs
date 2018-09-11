using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingUsingDecoratorPattern
{
    class MemoryCacheProductService : ICacheProductService
    {
        private IProductService _productService;
        private CacheOperations _memoryCachProvider;
        public MemoryCacheProductService()
        {
            _productService = new ProductService();
            _memoryCachProvider = new CacheOperations();
        }
        public Product GetProductById(int id)
        {
            Product product = (Product)_memoryCachProvider.GetItem(Convert.ToString(id));
            if (product != null)
            {
                Console.WriteLine("Data retrieved from Cache");
                return product;
            }
            product = _productService.GetProductById(id);
            _memoryCachProvider.AddItem(Convert.ToString(product.Id), product);
            return product;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = _productService.GetProducts();
            return products;
        }
    }
}
