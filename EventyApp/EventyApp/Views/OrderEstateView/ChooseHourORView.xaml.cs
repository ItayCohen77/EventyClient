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
    public partial class ChooseHourORView : ContentPage
    {
        public ChooseHourORView(string city, DateTime date, int peopleAmount)
        {
            ChooseHourORViewModel ChooseHourOR = new ChooseHourORViewModel(city, date, peopleAmount);
            this.BindingContext = ChooseHourOR;
            ChooseHourOR.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
        }
    }
}