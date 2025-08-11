namespace exercise.tests;
using exercise.main;
public class Tests
{
    [Test]
    public void AddItemTests()
    {
        Inventory inventory = new Inventory();
        Assert.That(inventory.GetProducts().Count(), Is.EqualTo(0));
        inventory.AddProduct(new Bagel("BGLO", "Onion", (decimal)0.49, 5));
        inventory.AddProduct(new Bagel("BGLP", "Plain", (decimal)0.39, 7));

        Assert.That(inventory.GetProducts().Count(), Is.EqualTo(2));
        inventory.AddProduct(new Coffee("COFB", "Black", (decimal)0.99, 47));
        Assert.That(inventory.GetProducts().Count(), Is.EqualTo(3));
        inventory.AddProduct(new Filling("FILB", "Bacon", (decimal)0.12, 15));

        Assert.That(inventory.GetProducts().Count(), Is.EqualTo(4));
    }


    [Test]
    public void RemoveItemTests()
    {
        Inventory inventory = new Inventory();
        Assert.That(inventory.GetProducts().Count(), Is.EqualTo(0));
        inventory.AddProduct(new Bagel("BGLO", "Onion", (decimal)0.49, 5));
        inventory.AddProduct(new Bagel("BGLP", "Plain", (decimal)0.39, 7));

        Assert.That(inventory.GetProducts().Count(), Is.EqualTo(2));
        inventory.RemoveProduct(new Coffee("COFB", "Black", (decimal)0.99, 47));
        Assert.That(inventory.GetProducts().Count(), Is.EqualTo(3));
        inventory.AddProduct(new Filling("FILB", "Bacon", (decimal)0.12, 15));

        Assert.That(inventory.GetProducts().Count(), Is.EqualTo(4));
    }
}


