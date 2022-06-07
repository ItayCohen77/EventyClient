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
    public partial class WishlistsView : ContentView
    {
        public WishlistsView()
        {
            InitializeComponent();
            WishlistsViewModel wishlists = new WishlistsViewModel();
            this.BindingContext = wishlists;
            wishlists.Push += (p) => Navigation.PushAsync(p);
        }
    }
}