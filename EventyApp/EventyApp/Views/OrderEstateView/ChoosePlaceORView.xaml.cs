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
    public partial class ChoosePlaceORView : ContentPage
    {
        public ChoosePlaceORView(string city, DateTime date, int peopleAmount, TimeSpan startTime, TimeSpan endTime, int totalHours)
        {
            ChoosePlaceORViewModel ChoosePlaceOR = new ChoosePlaceORViewModel(city, date, peopleAmount, startTime, endTime, totalHours);
            this.BindingContext = ChoosePlaceOR;
            ChoosePlaceOR.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
        }
    }
}