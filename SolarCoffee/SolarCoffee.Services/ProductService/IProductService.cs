using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCoffee.Data.Models;

namespace SolarCoffee.Services.ProductService
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        ServiceResponse<Product> CreateProduct(Product product);
        ServiceResponse<Product> ArchiveProduct(int id);
    }
}
