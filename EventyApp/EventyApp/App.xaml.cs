using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EventyApp.Views;

namespace EventyApp
{
    public partial class App : Application
    {
        public static bool IsDevEnv
        {
            get
            {
                return true; //change this before release!
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TabControlView());

            Sharpnado.Tabs.Initializer.Initialize(false, false);
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
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
