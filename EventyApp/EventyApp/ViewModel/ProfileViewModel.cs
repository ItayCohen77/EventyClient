using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using EventyApp.Views;

namespace EventyApp.ViewModel
{
    class ProfileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;

        public ICommand LogInCommand => new Command(LogIn);
        private void LogIn()
        {
            Push?.Invoke(new LoginView());
        }
        public ICommand SignUpCommand => new Command(SignUp);
        private void SignUp()
        {
            Push?.Invoke(new SignUpView());
        }
    }
}
