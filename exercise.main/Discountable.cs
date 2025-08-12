using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Discountable
    {
        private Dictionary<(string, int), decimal> BagelDiscounts = new Dictionary<(string, int), decimal>();

        private Dictionary<(string, string), decimal> CoffeeBagelDiscount = new Dictionary<(string, string), decimal>();

        public Discountable() {
            Inventory inventory = new Inventory();
            foreach (var product in inventory.GetProducts()) {
                if (product.GetName() == "Bagel")
                {
                    BagelDiscounts.Add((product.GetSKU(), 6), 2.49m);
                    BagelDiscounts.Add((product.GetSKU(), 12), 3.99m);

                    foreach (var product2 in inventory.GetProducts())
                    {
                        if (product.GetName() == "Coffee"){
                            CoffeeBagelDiscount.Add((product.GetSKU(), product2.GetSKU()), 0.99m);
                        }
                    }
                }
            }
        }




    }
}
