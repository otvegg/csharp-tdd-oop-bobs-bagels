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
        protected int Stock;

        public Product(string sku, string variant, decimal price, int stock)
        {
            SKU = sku;
            Variant = variant;
            Price = price;
            Stock = stock;
        }

        public void UpdateStock(int count)
        {
            Stock += count;
        }

        public string GetSKU() {  return SKU; }
        public int GetStock() { return Stock; }
    }
    public interface IProduct
    {

        Guid Id { get; set; }
        string SKU { get; set; }
        string Name { get; set; }
        string Variant { get; set; }
        decimal Price { get; set; }
        int Stock { get; set; }

        public void UpdateStock(int count);
    }
}
