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
    public partial class WelcomeHEView : ContentPage
    {
        public WelcomeHEView()
        {
            InitializeComponent();
            WelcomeHEViewModel welcomeHE = new WelcomeHEViewModel();
            this.BindingContext = welcomeHE;
            welcomeHE.Push += (p) => Navigation.PushAsync(p);
        }
    }
}