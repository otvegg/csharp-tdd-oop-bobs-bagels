using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product
    {
        protected Guid Id = Guid.NewGuid();
        protected string SKU;
        protected string Name;
        protected string Variant;
        protected decimal Price;

        public Product(string sku, string variant, decimal price) //int stock
        {
            SKU = sku;
            Variant = variant;
            Price = price;
            //Stock = stock;
        }

        public string GetSKU() {  return SKU; }
        public Guid GetId() { return Id; }
        public string GetVariant() { return Variant; }
        public decimal GetPrice() { return Price; }
        public string GetName() { return Name; }
    }
}
