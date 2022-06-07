using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EventyApp.Views;
using EventyApp.Models;
using Syncfusion;
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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTg2MTI3QDMxMzkyZTM0MmUzMGRJZkRxMkRTLy9kbERGSkppWU8wRlNWSUw5SnFOWjF3WTRHbGVsOVc2ams9");
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
