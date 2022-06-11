using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EventyApp.ViewModel;
using EventyApp.Models;

namespace EventyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventDetailsView : ContentPage
    {
        public EventDetailsView(Order o)
        {
            InitializeComponent();
            EventDetailsViewModel eventD = new EventDetailsViewModel(o);
            this.BindingContext = eventD;
            eventD.Push += (p) => Navigation.PushAsync(p);
        }
    }
}