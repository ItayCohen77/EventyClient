using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EventyApp.ViewModel;

namespace EventyApp.Views.HostEstateView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationHEView : ContentPage
    {
        public LocationHEView()
        {
            LocationHEViewModel LocationHE = new LocationHEViewModel();
            this.BindingContext = LocationHE;
            LocationHE.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
        }
    }
}