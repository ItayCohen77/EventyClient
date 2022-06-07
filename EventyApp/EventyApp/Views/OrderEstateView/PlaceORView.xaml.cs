using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EventyApp.ViewModel;
using EventyApp.Models;

namespace EventyApp.Views.OrderEstateView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaceORView : ContentPage
    {
        public PlaceORView(string city, DateTime date, int peopleAmount, TimeSpan startTime, TimeSpan endTime, int totalHours, int placeId)
        {
            PlaceORViewModel placeOR = new PlaceORViewModel(city, date, peopleAmount, startTime, endTime, totalHours, placeId);
            this.BindingContext = placeOR;
            placeOR.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
        }
    }
}