namespace exercise.tests;
using exercise.main;
using System.Reflection.Emit;

public class BasketTests
{
    // initiate inventory with stock mentioned in excercise description
    private Inventory _inventory =  new Inventory();

    [Test]
    public void AddCoffeeTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        Guid? blackCoffeId = basket.AddProduct(_inventory, new Coffee("COFB", "Onion", 0.49m));
        Assert.That(blackCoffeId, Is.Not.Null);

        Product product = basket.GetProduct(blackCoffeId.Value);
        Assert.That(product.GetSKU(), Is.EqualTo("COFB"));
    
    }

    [Test]
    public void AddCoffeeFailTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        Guid? success = basket.AddProduct(_inventory, new Coffee("KOKO", "ikkk", 999m));

        Assert.That(success, Is.Null);
    }

    [Test]
    public void AddEmptyBagelTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        Guid? bagelId = basket.AddProduct(_inventory, new Bagel("BGLO", "Onion", 0.49m));
        Assert.That(bagelId, Is.Not.Null);
        Product product = basket.GetProduct(bagelId.Value);
        Assert.That(product.GetSKU(), Is.EqualTo("BGLO"));
        Assert.That(product.GetVariant(), Is.EqualTo("Onion"));
    }

    [Test]
    public void AddTooManyBagels()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        for (int i = 0; i < 15; i++)
        {
            basket.AddProduct(_inventory, new Bagel("BGLO", "Onion", 0.49m));
        }
        Guid? bagelId = basket.AddProduct(_inventory, new Bagel("BGLO", "Onion", 0.49m));
        Assert.That(bagelId, Is.Null);
    }

    [Test]
    public void AddBagelWithFillingTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        Bagel bagel = new Bagel("BGLP", "Plain", 0.39m);
        bagel.AddFilling(_inventory, "FILS");
        Guid? bagelId = basket.AddProduct(_inventory, bagel);

        Assert.That(bagelId, Is.Not.Null);
        
        Product potentialBagel = basket.GetProduct(bagelId.Value);

        Assert.That(potentialBagel.GetSKU(), Is.EqualTo("BGLP"));
        
        if (potentialBagel.GetSKU() == "BGLP")
        {
            Bagel ConfirmedBagel = (Bagel)potentialBagel;
            List<Filling> fillings = ConfirmedBagel.GetFillings();
            if (fillings.Count() > 0) {
                Assert.That(fillings[0].GetSKU(), Is.EqualTo("FILS"));
            }
        }
    }

    [Test]
    public void AddBagelWithFillingFailTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        basket.AddProduct(_inventory, new Bagel("BGLO", "Onion", 0.49m));
        basket.AddProduct(_inventory, new Bagel("BGLP", "Plain", 0.39m));
        Bagel bagel = new Bagel("BGLP", "Plain", 0.39m);
        Guid? fillingId = bagel.AddFilling(_inventory, "KOOOR");

        Assert.That(fillingId, Is.Null);
    }

    [Test]
    public void RemoveItemTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        Guid? id1 = basket.AddProduct(_inventory, new Bagel("BGLO", "Onion", 0.49m));
        Guid? id2 = basket.AddProduct(_inventory, new Bagel("BGLP", "Plain", 0.39m));
        Guid? id3 = basket.AddProduct(_inventory, new Bagel("BGLE", "Everything", 0.39m));

        Assert.That(basket.GetProducts().Count(), Is.EqualTo(3));

        if (id2 == null) return;
        bool success = basket.RemoveProduct(id2.Value); 
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(2));
        Assert.That(success, Is.True);
    }

    [Test]
    public void RemoveZeroItemTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));

        bool success = basket.RemoveProduct(Guid.NewGuid());
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


    [Test]
    public void GetProductFailTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));

        Product product = basket.GetProduct("BGLO");
        Assert.That(product, Is.Null);
    }

    [Test]
    public void CheckPriceTest()
    {
        decimal price = _inventory.GetProduct("BGLO").GetPrice();

        Assert.That(price, Is.EqualTo(0.49m));
    }
}


