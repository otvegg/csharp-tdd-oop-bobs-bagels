namespace exercise.tests;
using exercise.main;
public class BasketTests
{
    private Inventory _inventory =  new Inventory();
    [SetUp]
    public void Setup()
    {
        _inventory.AddProduct("BGLO", new Product("BGLO", "Onion", 0.49m));
        _inventory.AddProduct("BGLP", new Product("BGLP", "Plain", 0.39m));
        _inventory.AddProduct("BGLE", new Product("BGLE", "Everything", 0.49m));
        _inventory.AddProduct("BGLS", new Product("BGLS", "Sesame", 0.49m));
        _inventory.AddProduct("COFB", new Product("COFB", "Black", 0.99m));
        _inventory.AddProduct("COFW", new Product("COFW", "White", 1.19m));
        _inventory.AddProduct("COFC", new Product("COFC", "Capuccino", 1.29m));
        _inventory.AddProduct("COFL", new Product("COFL", "Latte", 1.29m));
        _inventory.AddProduct("FILB", new Product("FILB", "Bacon", 0.12m));
        _inventory.AddProduct("FILE", new Product("FILE", "Egg", 0.12m));
        _inventory.AddProduct("FILC", new Product("FILC", "Cheese", 0.12m));
        _inventory.AddProduct("FILX", new Product("FILX", "Cream Cheese", 0.12m));
        _inventory.AddProduct("FILS", new Product("FILS", "Smoked Salmon", 0.12m));
        _inventory.AddProduct("FILH", new Product("FILH", "Ham", 0.12m));
    }

    [Test]
    public void AddCoffeeTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        basket.AddProduct(_inventory, new Coffee("BGLO", "Onion", 0.49m));
        basket.AddProduct(_inventory, new Bagel("BGLP", "Plain", 0.39m));

        Product product = basket.GetProduct("BGLO");
        Assert.That(product.GetSKU(), Is.EqualTo("BGLO"));
    }

    [Test]
    public void AddCoffeeFailTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        Guid? success = basket.AddProduct(_inventory, new Coffee("KOKO", "ikkk", 999m));

        Assert.That(success, Is.Null);
    }

    public void AddEmptyBagelTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        basket.AddProduct(_inventory, new Bagel("BGLO", "Onion", 0.49m));

        Product product = basket.GetProduct("BGLO");
        Assert.That(product.GetSKU(), Is.EqualTo("BGLO"));
        Assert.That(product.GetVariant(), Is.EqualTo("Onion"));
    }

    [Test]
    public void AddBagelWithFillingTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        basket.AddProduct(_inventory, new Bagel("BGLO", "Onion", 0.49m));
        basket.AddProduct(_inventory, new Bagel("BGLP", "Plain", 0.39m));

        Product product = basket.GetProduct("BGLO");
        Assert.That(product.GetSKU(), Is.EqualTo("BGLO"));
    }

    [Test]
    public void AddBagelWithFillingFailTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        basket.AddProduct(_inventory, new Bagel("BGLO", "Onion", 0.49m));
        basket.AddProduct(_inventory, new Bagel("BGLP", "Plain", 0.39m));

        Product product = basket.GetProduct("BGLO");
        Assert.That(product.GetSKU(), Is.EqualTo("BGLO"));
    }

    [Test]
    public void RemoveItemTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        basket.AddProduct(_inventory, new Bagel("BGLO", "Onion", 0.49m));
        basket.AddProduct(_inventory, new Bagel("BGLP", "Plain", 0.39m));

        Assert.That(basket.GetProducts().Count(), Is.EqualTo(2));
        bool success = basket.RemoveProduct("BGLO");
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(1));
        Assert.That(success, Is.True);
    }

    [Test]
    public void RemoveZeroItemTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));

        bool success = basket.RemoveProduct("BGLO");
        Assert.That(success, Is.False);
    }

    [Test]
    public void GetProductTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        basket.AddProduct(_inventory, new Bagel("BGLO", "Onion", 0.49m));
        basket.AddProduct(_inventory, new Bagel("BGLP", "Plain", 0.39m));

        Product product = basket.GetProduct("BGLO");
        Assert.That(product.GetSKU(), Is.EqualTo("BGLO"));
    }
}


