using exercise.main;
using System.Xml.Linq;

namespace exercise.tests
{
    public class Filling : Product
    {
        public Filling(string sku, string variant, decimal price)
             : base(sku, variant, price)
        {
            Name = "Filling";
        }
    }
}