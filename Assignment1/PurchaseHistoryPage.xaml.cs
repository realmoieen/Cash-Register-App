using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PurchaseHistoryPage : ContentPage
    {
        public IList<HistoryItem> purchaseHistory { get; private set; }
        public PurchaseHistoryPage()
        {
            InitializeComponent();
            initPurchaseHistory();

            BindingContext = this;
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            HistoryItem selectedItem = e.SelectedItem as HistoryItem;
            await Navigation.PushAsync(new HistoryDetailPage(selectedItem.ID));

        }

        async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            //HistoryItem tappedItem = e.Item as HistoryItem;
            //await Navigation.PushAsync(new HistoryDetailPage(tappedItem.ID));

        }

        public void initPurchaseHistory()
        {
            purchaseHistory = App.Database.GetItemsAsync().Result;
        }
    }
}