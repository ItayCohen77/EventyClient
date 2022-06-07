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
    public partial class ExploreView : ContentView
    {
        public ExploreView()
        {
            InitializeComponent();
            ExploreViewModel explore = new ExploreViewModel();
            this.BindingContext = explore;
            explore.Push += (p) => Navigation.PushAsync(p);
        }
    }
}