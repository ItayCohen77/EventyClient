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
    public partial class EventsView : ContentView
    {
        public EventsView()
        {
            InitializeComponent();
            EventsViewModel events = new EventsViewModel();
            this.BindingContext = events;
            events.Push += (p) => Navigation.PushAsync(p);
        }
    }
}