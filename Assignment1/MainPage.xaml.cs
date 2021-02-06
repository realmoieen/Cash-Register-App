using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assignment1
{

    public partial class MainPage : ContentPage
    {
        public int quantity = 0;

        public ObservableCollection<Item> items { get; private set; }
        public MainPage()
        {
            InitializeComponent();

            items = new ObservableCollection<Item>();
            items.Add(new Item("Pants", 40.59, 20));
            items.Add(new Item("Shoes", 200, 50));
            items.Add(new Item("Hats", 55.49, 10));
            items.Add(new Item("T-shirt", 24.99, 10));
            items.Add(new Item("Dress", 600.99, 24));

            BindingContext = this;
            //Quantity.Text = quantity.ToString();
        }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Item selectedItem = e.SelectedItem as Item;
            Item.Text = selectedItem.Name;

            if (!isQuantityValid()) Total.Text = (selectedItem.Price * Int32.Parse(Quantity.Text)).ToString();
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            Item tappedItem = e.Item as Item;
            Item.Text = tappedItem.Name;

            if (!isQuantityValid()) Total.Text = (tappedItem.Price * Int32.Parse(Quantity.Text)).ToString();
        }

        public void numberBtn(object sender, EventArgs e)
        {
            // update the quantity label
            Button b = sender as Button;
            if (!isQuantityValid()) Quantity.Text += b.Text;
            else Quantity.Text = b.Text;

            //update the total based on quantity
            foreach (Item i in items)
            {
                if (i.Name.Equals(Item.Text))
                {
                    Total.Text = (i.Price * Int32.Parse(Quantity.Text)).ToString();
                }
            }
        }
        public void Clear(object sender, EventArgs e)
        {
            Item.Text = "Type";
            Quantity.Text = "Quantity";
            Total.Text = "Total";
        }
        private Boolean isQuantityValid() { return Quantity.Text == "Quantity" || Quantity.Text == "0"; }
        public void Buy(object sender, EventArgs e)
        {
            var found = items.FirstOrDefault(x => x.Name.Equals(Item.Text));
            int i = items.IndexOf(found);
            if (i != -1)
            {

                if (isQuantityValid()) { DisplayAlert("Error", "Please, enter quantity above zero.", "OK"); return; }
                int quantity = Int32.Parse(Quantity.Text);

                //Check if the quantity available is in stock
                if (items[i].Quantity >= quantity)
                {
                    //Update the observable collection
                    Item nwitm = new Item(items[i].Name, items[i].Price, items[i].Quantity - quantity);
                    items[i] = nwitm;

                    //Log the purchase (works)
                    HistoryItem hi = new HistoryItem(DateTime.Now, items[i].Name, quantity, Double.Parse(Total.Text));
                    App.Database.SaveItemAsync(hi);//suspicious

                    //Reset the text fields
                    Clear(sender, e);
                }
                else
                {
                    //Item.Text = "Incorrect quantity, try again.";
                    DisplayAlert("Error", "Requested Quantity not available.", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Please, select an item you want to buy.", "OK");
            }
        }

        //Note: consider chagning the return type to Task
        async void serveManagerPanel(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ManagerPanelPage(items));
        }
    }
}
