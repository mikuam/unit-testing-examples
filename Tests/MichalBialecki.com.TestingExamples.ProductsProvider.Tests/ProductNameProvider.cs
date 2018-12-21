namespace MichalBialecki.com.TestingExamples.ProductsProvider.Tests
{
    public class ProductNameProvider : IProductNameProvider
    {
        public string GetProductName(string id)
        {
            return "Product " + id;
        }
    }
}
