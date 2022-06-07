using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using EventyApp.Views;
using EventyApp.Services;
using EventyApp.Models;
using System.Linq;

namespace EventyApp.ViewModel
{
    class WelcomeHEViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;
        private EventyAPIProxy proxy;
        public User currentUser;

        public ICommand LetsGoCommand => new Command(LetsGo);
        private void LetsGo()
        {
            Push?.Invoke(new Views.HostEstateView.TypeOfPlaceHEView());
        }

        public WelcomeHEViewModel()
        {
            Start();
        }

        public async void Start()
        {
            currentUser = ((App)App.Current).CurrentUser;
            if (currentUser == null)
            {
                bool notLog = await AlertLogIn();

                if (notLog)
                {
                    await PopAllTo(new EventyApp.Views.LoginView());
                }
                else
                {
                    await PopAllTo(new EventyApp.Views.SignUpView());
                }
            }          
        }
        public async Task<bool> AlertLogIn()
        {
            bool notLogin = await App.Current.MainPage.DisplayAlert("Alert", "You must log in/sign up to host a estate", "Log In", "Sign Up");

            return notLogin;
        }
        public async Task PopAllTo(Page page) // clear navigation stack and goes to page
        {
            App.Current.MainPage.Navigation.InsertPageBefore(page, App.Current.MainPage.Navigation.NavigationStack.First());
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}
