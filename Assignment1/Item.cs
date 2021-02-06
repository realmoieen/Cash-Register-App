using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Item(string name, double pr, int qu)
        {
            this.Name = name;
            this.Quantity = qu;
            this.Price = pr;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
