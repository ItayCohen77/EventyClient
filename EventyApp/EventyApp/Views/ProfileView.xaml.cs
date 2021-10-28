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
    public partial class ProfileView : ContentView
    {
        public ProfileView()
        {
            InitializeComponent();
            ProfileViewModel profileview = new ProfileViewModel();
            this.BindingContext = profileview;
            profileview.Push += (p) => Navigation.PushAsync(p);
        }
    }
}