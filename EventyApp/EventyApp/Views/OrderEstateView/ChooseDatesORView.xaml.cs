using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EventyApp.ViewModel;

namespace EventyApp.Views.OrderEstateView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseDatesORView : ContentPage
    {
        public ChooseDatesORView(string city)
        {
            ChooseDatesORViewModel ChooseDatesOR = new ChooseDatesORViewModel(city);
            this.BindingContext = ChooseDatesOR;
            ChooseDatesOR.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
        }               
    }
}