using System;
using FirebaseDB.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirebaseDB
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new StudentList());
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

