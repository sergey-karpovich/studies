

using Microsoft.AspNetCore.Mvc;
using SolarCoffee.Services.ProductService;
using SolarCoffee.Web.Serialization;
using SolarCoffee.Web.ViewModels;

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


        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/product")]
        public IActionResult GetProduct()
        {    
            _logger.LogInformation("Gettirg all products");
            var products = _productService.GetAllProducts();
            var productViewModels = products
                .Select(ProductMapper.SerializeProductModel); 
            
            return Ok(productViewModels);
        }

        /// <summary>
        /// Archives an existing product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("/api/product/{id}")]
        public ActionResult ArchiveProduct(int id)
        {
            _logger.LogInformation("Archiving product");
            var archiveResult = _productService.ArchiveProduct(id);
            return Ok();
        }

        /// <summary>
        /// Adds a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost("/api/product")]
        public ActionResult CreateProduct([FromBody] ProductModel product)
        {
            if (!ModelState.IsValid)            
                return BadRequest(ModelState);

            _logger.LogInformation("Creating new product" + product.Name);
            var newProduct =ProductMapper.SerializeProductModel(product);
            var newProductResponse=_productService.CreateProduct(newProduct);
            return Ok(newProductResponse);
        }
    }
}
