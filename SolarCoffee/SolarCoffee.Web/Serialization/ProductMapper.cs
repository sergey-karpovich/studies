using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Serialization
{
    public static class ProductMapper
    {
        /// <summary>
        /// Maps a Product data model a ProductVM view model
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static ProductVM SerializeProductModel(Product product)
        {
            return new ProductVM
            {
                Id = product.Id,
                Name = product.Name,
                CreatedOn = product.CreatedOn,
                UpdatedOn = product.UpdatedOn,
                Price = product.Price,
                Description = product.Description,
                IsArchived = product.IsArchived,
                IsTaxable = product.IsTaxable
            };
        }

        /// <summary>
        /// Maps a ProductVM view model to a Product data model
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static Product SerializeProductModel(ProductVM product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                CreatedOn = product.CreatedOn,
                UpdatedOn = product.UpdatedOn,
                Price = product.Price,
                Description = product.Description,
                IsArchived = product.IsArchived,
                IsTaxable = product.IsTaxable
            };
        }
    }
}
