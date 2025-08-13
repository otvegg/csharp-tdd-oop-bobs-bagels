using exercise.tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private static int Capacity = 25;
        private Dictionary<Guid, Product> products = new Dictionary<Guid, Product>();

        public int GetCapacity() => Capacity;

        public decimal GetBasketTotal(bool ApplyDiscount = false) {

            if (ApplyDiscount) {
                // first count number of each bagel SKU


                Dictionary<string, int> SKUs = products.Values.GroupBy(product => product.GetSKU()).ToDictionary(group => group.Key, group => group.Count());
                // Alternative but not that cool
                // Dictionary<string, int> SKUs = new Dictionary<string, int>();
                //foreach (var product in products.Values) {
                //    SKUs[product.GetSKU()] = SKUs.TryGetValue(product.GetSKU(), out var count) ? count + 1 : 1;
                //}


                Dictionary<string, int> bagelSKUs = SKUs.Where(sku => sku.Key.Contains("BGL")).ToDictionary();
                int COFBs = products.Values.Where(product => product.GetSKU().Contains("COFB")).Count();


                // check how many bagels that fit into the 6/12 discount. If any bagels left, check if any coffees
                decimal BasketValue = 0;
                foreach (var sku in bagelSKUs)
                {
                    decimal n_12s = 0;
                    decimal n_6s = 0;
                    decimal noDiscount = 0;
                    int bagelCOFBCombo = 0;
                    if (sku.Value >= 12)
                    {
                        n_12s = Math.Floor(sku.Value / 12m);
                        decimal remainder = sku.Value % 12;
                        n_6s = remainder >= 6m ? 1 : 0;
                        noDiscount = remainder % 6;
                    }
                    else if (sku.Value >= 6)
                    {
                        n_6s++;
                        noDiscount = sku.Value % 6;
                    }
                    else noDiscount = sku.Value;

                    //iterate number of combos of coffee+bagel
                    for (; bagelCOFBCombo < Math.Min(COFBs, noDiscount); bagelCOFBCombo++) ;

                    COFBs -= bagelCOFBCombo;
                    BasketValue += n_12s * 3.99m + n_6s * 2.49m + noDiscount * GetProduct(sku.Key).GetPrice();

                }

                foreach (var product in products.Values)
                {
                    // only add fillings
                    string sku = product.GetSKU();
                    if (sku.Contains("BGL")) BasketValue += (product as Bagel).GetFillingPrice();
                    else if (sku.Equals("COFB") && COFBs > 0)
                    {
                        COFBs -= 1;
                        BasketValue += product.GetPrice();
                    } else BasketValue += product.GetPrice();

                }



                return BasketValue;

                // check for fillings
            } else return products.Values.Sum(product => product.GetPrice());
        }
        public Guid? AddProduct(Inventory inventory, Product product)
        {
            if (!inventory.HasProduct(product.GetSKU())) return null;
            else if (products.Count() == Capacity) return null;

            products.Add(product.GetId(), product);

            return product.GetId();
        }


        public Product GetProduct(Guid id) { return products[id]; }
        public Product GetProduct(string SKU) { 
            return products.Values.FirstOrDefault(product => product.GetSKU() == SKU); 
        }


        public List<Product> GetProducts() { return products.Values.ToList(); }

        public bool RemoveProduct(Guid id)
        {
            // check if item is in basket
            if (products.Values.Any(product => product.GetId().Equals(id)))
            {
                return products.Remove(id);
            }
            else return false;
        }

        public string GetReceipt()
        {
            string ReceiptSeperator = "\n------------------------------\n";
            string Receipt = $"    ~~~ Bob's Bagels ~~~\n\n     {DateTime.Now}\n{ReceiptSeperator}\n";

            Dictionary<string, int> SKUs = products.Values.GroupBy(product => product.GetSKU()).ToDictionary(group => group.Key, group => group.Count());

            Dictionary<string, int> bagelSKUs = SKUs.Where(sku => sku.Key.Contains("BGL")).ToDictionary();
            int COFBs = products.Values.Where(product => product.GetSKU().Contains("COFB")).Count();
            

            // check how many bagels that fit into the 6/12 discount. If any bagels left, check if any coffees
            decimal BasketValue = 0;
            foreach (var sku in bagelSKUs)
            {
                decimal n_12s = 0;
                decimal n_6s = 0;
                decimal noDiscount = 0;
                int bagelCOFBCombo = 0;
                if (sku.Value >= 12)
                {
                    n_12s = Math.Floor(sku.Value / 12m);
                    decimal remainder = sku.Value % 12;
                    n_6s = remainder >= 6m ? 1 : 0;
                    noDiscount = remainder % 6;
                }
                else if (sku.Value >= 6)
                {
                    n_6s++;
                    noDiscount = sku.Value % 6;
                }
                else noDiscount = sku.Value;

                //iterate number of combos of coffee+bagel
                for (; bagelCOFBCombo < Math.Min(COFBs, noDiscount); bagelCOFBCombo++) ;

                COFBs -= bagelCOFBCombo;


                decimal discount = GetProduct(sku.Key).GetPrice() * sku.Value -  (n_6s * 2.49m + n_12s * 3.99m);
                Receipt += ""
                BasketValue += n_12s * 3.99m + n_6s * 2.49m + noDiscount * GetProduct(sku.Key).GetPrice();

                foreach (var product in products.Values.Where(product => (product.GetSKU() == sku.Key)))
                {
                    BasketValue += (product as Bagel).GetFillingPrice();
                    List<Filling> fillings = (product as Bagel).GetFillings();
                    if (fillings.Count > 0)
                    {
                        foreach (var filling in fillings) { 
                            Receipt += $"     * {filling.GetVariant()} -  £{filling.GetPrice()}\n"; 
                        }

                    }
                }
                
            }

            foreach (var product in products.Values)
            {
                // only add fillings
                string sku = product.GetSKU();
                if (sku.Contains("BGL")) BasketValue += (product as Bagel).GetFillingPrice();
                else if (sku.Equals("COFB") && COFBs > 0)
                {
                    COFBs -= 1;
                    BasketValue += product.GetPrice();
                }
                else BasketValue += product.GetPrice();

            }

            // Original
            foreach (var product in products.Values)
            {
                Receipt += $"    {product.GetName()}, {product.GetVariant()} - £{product.GetPrice()}\n";
                if (product is Bagel bagel)
                {
                    List<Filling> fillings = bagel.GetFillings();
                    if (fillings.Count > 0)
                    {
                        foreach (var filling in fillings) Receipt += $"     * {filling.GetVariant()} -  £{filling.GetPrice()}\n";
                        
                    }
                }
            }

            Receipt += ReceiptSeperator;
            Receipt += $"Total                  £{GetBasketTotal(true)}";
            return Receipt;

        }
    }
}
