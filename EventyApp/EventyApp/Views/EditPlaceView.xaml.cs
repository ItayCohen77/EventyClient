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
    public partial class EditPlaceView : ContentPage
    {
        public EditPlaceView(Place place)
        {
            InitializeComponent();
            EditPlaceViewModel edit = new EditPlaceViewModel(place);
            this.BindingContext = edit;
            edit.Push += (p) => Navigation.PushAsync(p);
        }
    }
}