using exercise.tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Product
    {
        private int MaxFillings = 10;
        private Dictionary<string, Filling> fillings = new Dictionary<string,Filling>();

        public Bagel(string sku, string variant, decimal price)
             : base(sku, variant, price)
        {
            Name = "Bagel";
        }

        public Guid? AddFilling(Inventory inventory, string SKU)
        {
            if (!inventory.HasProduct(SKU)) return null;
            Product potentialFilling = inventory.GetProduct(SKU);
            Filling? filling = null;
            if (potentialFilling == null || potentialFilling.GetName() != "Filling") return null;
            else filling = potentialFilling as Filling;
            
            if (filling == null || !inventory.HasProduct(filling.GetSKU())) return null;
            if (fillings.Count >= MaxFillings) return null;

            fillings.Add(filling.GetSKU(), filling);
            return filling.GetId();
        }

        public decimal GetFillingPrice() { return fillings.Values.Sum(fillings => fillings.GetPrice()); }

        public List<Filling> GetFillings() 
        {
            return fillings.Values.ToList();
        }
    }
}
