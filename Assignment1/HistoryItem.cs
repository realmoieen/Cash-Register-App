using System;
using System.Collections.Generic;
using SQLite;

namespace Assignment1
{
    public class HistoryItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime date { get; set; }
        public string itemName { get; set; }
        public int quantity { get; set; }
        public double totalPrice { get; set; }

        public HistoryItem()
        {
        }
        public HistoryItem(DateTime date, string name, int quantity, double total)
        {
            this.date = date;
            this.itemName = name;
            this.quantity = quantity;
            this.totalPrice = total;
        }

        public override string ToString()
        {
            return "Item = =  = = = " + this.itemName + " " + this.quantity + " " + this.date + " " + this.totalPrice;
        }

    }
}
