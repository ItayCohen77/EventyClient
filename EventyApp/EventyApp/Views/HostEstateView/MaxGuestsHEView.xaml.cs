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
    public partial class MaxGuestsHEView : ContentPage
    {
        public MaxGuestsHEView(string typePlace, string featureOne, string featureTwo, string featureThree, string featureFour, string featureFive, string description, string imageOne, string imageTwo, string imageThree, string imageFour, string imageFive, string imageSix, string street, string apartment, string city, string zip, string country)
        {
            MaxGuestsHEViewModel maxGuestsHE = new MaxGuestsHEViewModel(typePlace, featureOne, featureTwo, featureThree, featureFour, featureFive, description, imageOne, imageTwo, imageThree, imageFour, imageFive, imageSix, street, apartment, city, zip, country);
            this.BindingContext = maxGuestsHE;
            maxGuestsHE.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
        }
    }
}