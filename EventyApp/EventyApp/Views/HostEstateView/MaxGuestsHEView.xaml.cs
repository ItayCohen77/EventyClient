using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EventyApp.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using EventyApp.Services;
using EventyApp.Views;
using EventyApp.Models;
using Xamarin.Essentials;

namespace EventyApp.Views.HostEstateView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaxGuestsHEView : ContentPage
    {
        public MaxGuestsHEView(string typePlace, bool featureOneBool, bool featureTwoBool, bool featureThreeBool, bool featureFourBool, bool featureFiveBool, string description, FileResult imageOne, FileResult imageTwo, FileResult imageThree, FileResult imageFour, FileResult imageFive, FileResult imageSix, string street, string apartment, string city, string zip, string country)
        {
            MaxGuestsHEViewModel maxGuestsHE = new MaxGuestsHEViewModel(typePlace, featureOneBool, featureTwoBool, featureThreeBool, featureFourBool, featureFiveBool, description, imageOne, imageTwo, imageThree, imageFour, imageFive, imageSix, street, apartment, city, zip, country);
            this.BindingContext = maxGuestsHE;
            maxGuestsHE.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
        }
    }
}