using exercise.main;

namespace exercise.tests;

public class DiscountTests
{
    // initiate inventory with stock mentioned in excercise description
    private Inventory _inventory = new Inventory();

    [Test]
    public void SixBagelsTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        for (int i = 0; i < 6; i++) {
            basket.AddProduct(_inventory, new Bagel("BGLO", "Onion", 0.49m));
        }

        decimal value = basket.GetBasketTotal(true);
        Assert.That(value, Is.EqualTo(2.49m));
    }

    [Test]
    public void TwelveBagelsTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        for (int i = 0; i < 12; i++)
        {
            basket.AddProduct(_inventory, new Bagel("BGLO", "Onion", 0.49m));
        }

        decimal value = basket.GetBasketTotal(true);
        Assert.That(value, Is.EqualTo(3.99m));
    }

    [Test]
    public void SixTwelveBagelsTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        for (int i = 0; i < 12; i++)
        {
            basket.AddProduct(_inventory, new Bagel("BGLO", "Onion", 0.49m));
        }
        for (int i = 0; i < 6; i++)
        {
            basket.AddProduct(_inventory, new Bagel("BGLO", "Onion", 0.49m));
        }

        decimal value = basket.GetBasketTotal(true);
        Assert.That(value, Is.EqualTo(3.99m+2.49m));
    }
    [Test]
    public void SixBagelsWithFillingsTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));

        for (int i = 0; i < 6; i++)
        {
            basket.AddProduct(_inventory, new Bagel("BGLP", "Plain", 0.39m));
            // add fillings
        }

        decimal value = basket.GetBasketTotal(true);
        //Assert.That(value, Is.EqualTo(3.99m + 2.49m));
    }

    [Test]
    public void CoffeeBagelTest()
    {
        Basket basket = new Basket();
        Assert.That(basket.GetProducts().Count(), Is.EqualTo(0));
        basket.AddProduct(_inventory, new Bagel("BGLP", "Plain", 0.39m));
        basket.AddProduct(_inventory, new Coffee("COFB", "Black", 0.99m));
    }

    [Test]
    public void CoffeeSixBagelsTest()
    {
        Assert.Pass();
    }
}
