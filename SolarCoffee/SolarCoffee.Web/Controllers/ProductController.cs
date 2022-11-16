

using Microsoft.AspNetCore.Mvc;
using SolarCoffee.Services.ProductService;
using SolarCoffee.Web.Serialization;

namespace SolarCoffee.Web.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("/api/products")]
        public IActionResult GetProduct()
        {
            _logger.LogInformation("Gettirg all products");
            var products = _productService.GetAllProducts();
            var productViewModels = products
                .Select(ProductMapper.SerializeProductModel); 
            
            return Ok(productViewModels);
        }
    }
}
