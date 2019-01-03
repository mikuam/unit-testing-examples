using System;
using System.Linq;
using MichalBialecki.com.TestingExamples.Web.Product;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using NSubstitute;
using NUnit.Framework;

namespace MichalBialecki.com.TestingExamples.Web.Tests.Product
{
    [TestFixture]
    public class ProductsControllerTests
    {
        private IProductService _productService;
        private ILogger _logger;

        private ProductsController _productsController;

        [SetUp]
        public void SetUp()
        {
            _productService = Substitute.For<IProductService>();
            _logger = Substitute.For<ILogger>();
            var loggerFactory = Substitute.For<ILoggerFactory>();
            loggerFactory.CreateLogger(Arg.Any<string>()).Returns(_logger);

            _productsController = new ProductsController(_productService, loggerFactory);
        }

        [Test]
        public void Post_GivenCorrectProduct_ReturnsProductGuid()
        {
            // Arrange
            var guid = "af95003e-b31c-4904-bfe8-c315c1d2b805";
            var product = new ProductDto { ProductId = "1", ProductName = "Oven", QuantityAvailable = 3 };
            _productService.SaveProduct(product).Returns(guid);

            // Act
            var result = _productsController.Post(product);

            // Assert
            Assert.AreEqual(result, guid);
            _productService.Received(1).SaveProduct(product);
            _logger
                .Received(1)
                .Log(LogLevel.Information, 0, Arg.Is<FormattedLogValues>(v => v.First().Value.ToString().Contains(product.ProductId)), Arg.Any<Exception>(), Arg.Any<Func<object, Exception, string>>());
        }

        [Test]
        public void Post_GivenNullProduct_ThrowsNullReferenceException()
        {
            // Act &  Assert
            Assert.Throws<NullReferenceException>(() => _productsController.Post(null));
        }

        [Test]
        public void Post_GivenNullProduct_ThrowsNullReferenceExceptionWithMessage()
        {
            // Act &  Assert
            var exception = Assert.Throws<NullReferenceException>(() => _productsController.Post(null));
            Assert.AreEqual("Object reference not set to an instance of an object.", exception.Message);
        }

        [Test]
        public void Post_GivenNullProductId_ThrowsArgumentNullException()
        {
            // Arrange
            var guid = "af95003e-b31c-4904-bfe8-c315c1d2b805";
            var product = new ProductDto { ProductId = null, ProductName = "Oven", QuantityAvailable = 3 };
            _productService.SaveProduct(product).Returns(guid);

            // Act &  Assert
            var exception = Assert.Throws<ArgumentNullException>(() => _productsController.Post(null));
            Assert.True(exception.Message.Contains(nameof(ProductDto.ProductId)));

        }
    }
}