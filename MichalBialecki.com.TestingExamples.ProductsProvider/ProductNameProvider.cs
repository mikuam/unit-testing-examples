namespace MichalBialecki.com.TestingExamples.ProductsProvider
{
    public class ProductNameProvider : IProductNameProvider
    {
        public string GetProductName(string id)
        {
            return "Product " + id;
        }
    }
}
