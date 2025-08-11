using exercise.tests;

namespace exercise.main
{
    public class Inventory
    {
        private Dictionary<string, Product> products = new Dictionary<string, Product>();

        public void AddProduct(Product product) { products.Add(product.GetSKU(), product); }
        public bool RemoveProduct(string SKU) { return products.Remove(SKU); }

        public List<Product> GetProducts() { return [.. products.Values]; }

        public void AdjustStock(string SKU, int NewStock)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(string SKU) {
            throw new NotImplementedException();}
        }
}
