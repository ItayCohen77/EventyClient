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
        public MaxGuestsHEView()
        {
            MaxGuestsHEViewModel maxGuestsHE = new MaxGuestsHEViewModel();
            this.BindingContext = maxGuestsHE;
            maxGuestsHE.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
        }
    }
}