using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment1
{
    public partial class App : Application
    {
        static PurchaseItemDatabase database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public static PurchaseItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PurchaseItemDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
