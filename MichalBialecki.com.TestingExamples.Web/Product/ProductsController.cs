using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MichalBialecki.com.TestingExamples.Web.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger _logger;

        public ProductsController(IProductService productService, ILoggerFactory loggerFactory)
        {
            _productService = productService;
            _logger = loggerFactory.CreateLogger(nameof(ProductsController));
        }

        [HttpPost]
        public string Post([FromBody] ProductDto product)
        {
            _logger.Log(LogLevel.Information, $"Adding a products with an id {product.ProductId}");

            var productGuid = _productService.SaveProduct(product);

            return productGuid;
        }
    }
}
