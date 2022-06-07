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
    public partial class EditUserInfoView : ContentPage
    {
        public EditUserInfoView()
        {
            InitializeComponent();
            EditUserInfoViewModel edit = new EditUserInfoViewModel();
            this.BindingContext = edit;
            edit.Push += (p) => Navigation.PushAsync(p);
        }
    }
}