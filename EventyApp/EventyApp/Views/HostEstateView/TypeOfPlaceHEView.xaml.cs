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
    public partial class TypeOfPlaceHEView : ContentPage
    {
        public TypeOfPlaceHEView()
        {
            TypeOfPlaceHEViewModel TypeOfPlaceHE = new TypeOfPlaceHEViewModel();
            this.BindingContext = TypeOfPlaceHE;
            TypeOfPlaceHE.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
            
           
        }
    }
}