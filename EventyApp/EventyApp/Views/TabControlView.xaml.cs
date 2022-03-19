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
    public partial class TabControlView : ContentPage
    {       
        public TabControlView()
        {      
            TabControlViewModel tabs = new TabControlViewModel();
            this.BindingContext = tabs;
            tabs.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
        }
    }
}