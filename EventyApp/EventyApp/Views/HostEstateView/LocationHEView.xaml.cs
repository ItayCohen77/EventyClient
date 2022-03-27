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
        public LocationHEView(string typePlace, string featureOne, string featureTwo, string featureThree, string featureFour, string featureFive, string description, string imageOne, string imageTwo, string imageThree, string imageFour, string imageFive, string imageSix)
        {
            LocationHEViewModel LocationHE = new LocationHEViewModel(typePlace, featureOne, featureTwo, featureThree, featureFour, featureFive, description, imageOne, imageTwo, imageThree, imageFour, imageFive, imageSix);
            this.BindingContext = LocationHE;
            LocationHE.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
        }
    }
}