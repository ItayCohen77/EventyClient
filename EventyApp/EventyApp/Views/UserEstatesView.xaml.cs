using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EventyApp.ViewModel;

namespace EventyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserEstatesView : ContentView
    {
        public UserEstatesView()
        {
            InitializeComponent();
            UserEstatesViewModel estates = new UserEstatesViewModel();
            this.BindingContext = estates;
            estates.Push += (p) => Navigation.PushAsync(p);
        }
    }
}