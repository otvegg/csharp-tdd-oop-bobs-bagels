using exercise.tests;

namespace exercise.main
{
    public class Inventory
    {

        private Dictionary<string, Product> products = new Dictionary<string, Product>();
        public Inventory(bool StandardStock = true)
        {
            if (StandardStock) {
                AddProduct(new Bagel("BGLO", "Onion", 0.49m));
                AddProduct(new Bagel("BGLP", "Plain", 0.39m));
                AddProduct(new Bagel("BGLE", "Everything", 0.49m));
                AddProduct(new Bagel("BGLS", "Sesame", 0.49m));
                AddProduct(new Coffee("COFB", "Black", 0.99m));
                AddProduct(new Coffee("COFW", "White", 1.19m));
                AddProduct(new Coffee("COFC", "Capuccino", 1.29m));
                AddProduct(new Coffee("COFL", "Latte", 1.29m));
                AddProduct(new Filling("FILB", "Bacon", 0.12m));
                AddProduct(new Filling("FILE", "Egg", 0.12m));
                AddProduct(new Filling("FILC", "Cheese", 0.12m));
                AddProduct(new Filling("FILX", "Cream Cheese", 0.12m));
                AddProduct(new Filling("FILS", "Smoked Salmon", 0.12m));
                AddProduct(new Filling("FILH", "Ham", 0.12m));
                }
        }

        public void AddProduct(Product product) { products.Add(product.GetSKU(), product); }
        public bool RemoveProduct(string SKU) { return products.Remove(SKU); }

        public List<Product> GetProducts() { return [.. products.Values]; }
        public bool HasProduct(string SKU) { return products.Values.Any(product => (product.GetSKU() == SKU)); }

        public Product GetProduct(string SKU) { return products[SKU];   }
    }
}
