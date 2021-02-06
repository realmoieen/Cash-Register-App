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
    public partial class ManagerPanelPage : ContentPage
    {
        ObservableCollection<Item> items;
        public ManagerPanelPage(ObservableCollection<Item> it)
        {
            InitializeComponent();
            items = it;
        }

        async void redirect(object sender, EventArgs e)
        {
            Button b = sender as Button;

            if(b.Text.Equals("History")) await Navigation.PushAsync(new PurchaseHistoryPage());
            else if (b.Text.Equals("Restock")) await Navigation.PushAsync(new RestockPage(items));
            else await Navigation.PushAsync(new AddNewProductPage(items));
        }
    }
}