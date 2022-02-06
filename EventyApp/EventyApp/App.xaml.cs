using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EventyApp.Views;
using EventyApp.Models;

namespace EventyApp
{
    public partial class App : Application
    {
        public User CurrentUser;
        public static bool IsDevEnv
        {
            get
            {
                return true; //change this before release!
            }
        }

        private string typePlace;
        public string TypePlace
        {
            get
            {
                return this.typePlace;
            }
            set
            {
                if (this.typePlace != value)
                {
                    this.typePlace = value;
                    OnPropertyChanged(nameof(TypePlace));
                }
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
