using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{


    public class Coffee : Product
    {

        public Coffee(string sku, string variant, decimal price, int stock)
            : base(sku, variant, price, stock)
        {
            Name = "Coffee";
        }
    }
}
