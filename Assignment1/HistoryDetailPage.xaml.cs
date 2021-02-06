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
    public partial class HistoryDetailPage : ContentPage
    {
        int detailItemId;
        public HistoryDetailPage(int id)
        {
            InitializeComponent();
            detailItemId = id;
            HistoryItem hi = App.Database.GetItemAsync(detailItemId).Result;
            ItemName.Text = hi.itemName;
            ItemTotalAmount.Text = "Total amount: " + hi.totalPrice;
            ItemPurchaseDate.Text = hi.date.ToString();
            ItemQuantity.Text = hi.quantity.ToString();
        }


    }
}