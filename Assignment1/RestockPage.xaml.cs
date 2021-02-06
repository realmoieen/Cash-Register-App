using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestockPage : ContentPage
    {
        public ObservableCollection<Item> items { get; private set; }
        public Item selectedOrTappedItem = null;
        public RestockPage(ObservableCollection<Item> it)
        {
            InitializeComponent();
            items = it;
            //fffConsole.WriteLine(items[1].Name);
            BindingContext = this;
        }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedOrTappedItem = e.SelectedItem as Item;
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            selectedOrTappedItem = e.Item as Item;
        }
        async private void cancelBtn(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void restockBtn(object sender, EventArgs e)
        {
            if (!entryQuantity.Text.Equals(""))
            {
                if (selectedOrTappedItem!=null)
                {
                    var found = items.FirstOrDefault(x => x.Name.Equals(selectedOrTappedItem.Name));
                    int i = items.IndexOf(found);
                    int quantityToAdd=0;
                    try
                    {
                        quantityToAdd =Int32.Parse(entryQuantity.Text);
                    }catch(Exception ex)
                    {
                        DisplayAlert("Error", "Please, Enter quantity in numbers.", "OK");
                        return;
                    }
                    Item nwitm = new Item(items[i].Name, items[i].Price, items[i].Quantity + quantityToAdd);
                    items[i] = nwitm;

                    //clear the field
                    entryQuantity.Text = "";
                    selectedOrTappedItem = null;
                }
                else
                {
                    DisplayAlert("Error", "You have to select a item and provide a new quantity", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "You have to select a item and provide a new quantity", "OK");
            }
        }
    }
}