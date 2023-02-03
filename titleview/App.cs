using System;
using titleview.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace titleview
{
    public partial class App : Application
    {

        public App()
        {
            MainPage = new NavigationPage(new AboutPage());
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
