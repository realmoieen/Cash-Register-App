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
    public partial class AddNewProductPage : ContentPage
    {
        public ObservableCollection<Item> items { get; private set; }
        public AddNewProductPage(ObservableCollection<Item> it)
        {
            InitializeComponent();
            items = it;
        }
         async public void toolBarBtns(object sender, EventArgs e)
        {
            ToolbarItem t = sender as ToolbarItem;
            if (t.Text.Equals("Save"))
            {
                if (!addItmName.Text.Equals("") && !addItmPrice.Text.Equals("") && !addItmQuantity.Text.Equals(""))
                {
                    Item nw = new Item(addItmName.Text, Double.Parse(addItmPrice.Text), Int32.Parse(addItmQuantity.Text));
                    items.Add(nw);
                    addItmQuantity.Text = String.Empty;
                    addItmPrice.Text = String.Empty; 
                    addItmName.Text = String.Empty; 
                }
                else
                {
                    await DisplayAlert("Error", "Please, fill out the form", "Ok");
                }
            }
            else
            {
                await Navigation.PopAsync();
            }
        }
    }
}