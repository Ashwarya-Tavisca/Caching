using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingUsingDecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductService productService = new MemoryCacheProductService();
            List<Product> products = productService.GetProducts();
            Console.WriteLine("Enter number of Times you want data to be retrieved");
            int times = int.Parse(Console.ReadLine());
            while (times>0)
            {
                int id = int.Parse(Console.ReadLine());
                Product product = productService.GetProductById(id);
                Console.WriteLine(product.Id);
                times--;
            }
            Console.ReadKey();
        }
    }
}
