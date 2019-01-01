using MichalBialecki.com.TestingExamples.ProductsProvider.Tests;
using NUnit.Framework;

namespace MichalBialecki.com.TestingExamples.ProductsProvider
{
    [TestFixture]
    public class ProductNameProviderTests
    {
        [Test]
        public void GetProductName_GivenProductId_ReturnsProductName()
        {
            // Arrange
            var productId = "1";
            var productNameProvider = new ProductNameProvider();

            // Act
            var result = productNameProvider.GetProductName(productId);

            // Arrange
            Assert.AreEqual("Product " + productId, result);
        }
    }
}
