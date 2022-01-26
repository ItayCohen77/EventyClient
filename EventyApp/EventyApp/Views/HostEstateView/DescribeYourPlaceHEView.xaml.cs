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
    public partial class DescribeYourPlaceHEView : ContentPage
    {
        public DescribeYourPlaceHEView()
        {
            DescribeYourPlaceHEViewModel describe = new DescribeYourPlaceHEViewModel();
            this.BindingContext = describe;
            describe.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
        }
    }
}