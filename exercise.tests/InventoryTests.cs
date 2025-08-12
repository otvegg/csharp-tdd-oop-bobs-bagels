namespace exercise.tests;
using exercise.main;
public class InventoryTests
{
    [Test]
    public void AddItemTest()
    {
        Inventory inventory = new Inventory(false);
        Assert.That(inventory.GetProducts().Count(), Is.EqualTo(0));
        inventory.AddProduct(new Bagel("BGLO", "Onion", (decimal)0.49));
        inventory.AddProduct(new Bagel("BGLP", "Plain", (decimal)0.39));

        Assert.That(inventory.GetProducts().Count(), Is.EqualTo(2));
        inventory.AddProduct(new Coffee("COFB", "Black", (decimal)0.99));
        Assert.That(inventory.GetProducts().Count(), Is.EqualTo(3));
        inventory.AddProduct(new Filling("FILB", "Bacon", (decimal)0.12));

        Assert.That(inventory.GetProducts().Count(), Is.EqualTo(4));
    }


    [Test]
    public void RemoveItemTest()
    {
        Inventory inventory = new Inventory(false);
        Assert.That(inventory.GetProducts().Count(), Is.EqualTo(0));
        inventory.AddProduct(new Bagel("BGLO", "Onion", (decimal)0.49));
        inventory.AddProduct(new Bagel("BGLP", "Plain", (decimal)0.39));

        Assert.That(inventory.GetProducts().Count(), Is.EqualTo(2));
        bool success = inventory.RemoveProduct("BGLO");
        Assert.That(inventory.GetProducts().Count(), Is.EqualTo(1));
        Assert.That(success, Is.True);
    }

    [Test]
    public void GetProductTest()
    {
        Inventory inventory = new Inventory(false);
        Assert.That(inventory.GetProducts().Count(), Is.EqualTo(0));
        inventory.AddProduct(new Bagel("BGLO", "Onion", (decimal)0.49));
        inventory.AddProduct(new Bagel("BGLP", "Plain", (decimal)0.39));

        Product product = inventory.GetProduct("BGLO");
        Assert.That(product.GetSKU(), Is.EqualTo("BGLO"));
    }


    //[TestCase(15)]
    //[TestCase(913)]
    //[TestCase(-1)]
    //public void AdjustStockTest(int NewStock)
    //{
    //    Inventory inventory = new Inventory();
    //    Assert.That(inventory.GetProducts().Count(), Is.EqualTo(0));
    //    inventory.AddProduct(new Bagel("BGLO", "Onion", (decimal)0.49));
    //    inventory.AdjustStock("BGLO", NewStock);

    //    Assert.That(inventory.GetProduct("BGLO").GetStock(), Is.EqualTo(NewStock+20));
    //}
}


