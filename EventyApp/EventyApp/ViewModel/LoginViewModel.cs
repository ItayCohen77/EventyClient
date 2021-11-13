using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using EventyApp.Views;
using EventyApp.Services;
using EventyApp.Models;

namespace EventyApp.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;

        private EventyAPIProxy proxy;

        public LoginViewModel()
        {
            EmailError = "Must be a valid email address";

            this.LoginCommand = new Command(() => Login());

            proxy = EventyAPIProxy.CreateProxy();
        }

        public Command LoginCommand { protected set; get; }
        private async void Login()
        {
            if (ValidateForm())
            {
                User u = await proxy.Login(Email, Password);
                if (u != null)
                {
                    ((App)App.Current).CurrentUser = u;                   

                    Push.Invoke(new TabControlView());
                }
                else
                {
                    GeneralError = "Unknown error occurred. Please try again later";
                }

            }
        }

        private bool showEmailError;

        public bool ShowEmailError
        {
            get => showEmailError;
            set
            {
                showEmailError = value;
                OnPropertyChanged("ShowEmailError");
            }
        }

        private string email;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                //if (this.ShowEmailError)
                //    ValidateEmail();
                OnPropertyChanged("Email");
            }
        }

        private string emailError;

        public string EmailError
        {
            get => emailError;
            set
            {
                emailError = value;
                OnPropertyChanged("EmailError");
            }
        }

        private void ValidateEmail()
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                this.ShowEmailError = addr.Address != email;
            }
            catch
            {
                this.ShowEmailError = true;
            }

        }

        private bool showPasswordError;

        public bool ShowPasswordError
        {
            get => showPasswordError;
            set
            {
                showPasswordError = value;
                OnPropertyChanged("ShowPasswordError");
            }
        }

        private string password;

        public string Password
        {
            get => password;
            set
            {
                password = value;
                //if (this.ShowEmailError)
                //    ValidatePassword();
                OnPropertyChanged("Password");
            }
        }

        private string passwordError;

        public string PasswordError
        {
            get => passwordError;
            set
            {
                passwordError = value;
                OnPropertyChanged("PasswordError");
            }
        }

        private void ValidatePassword()
        {
            ShowPasswordError = true;
            if (string.IsNullOrEmpty(Password))
                PasswordError = "Password cannot be blank";
            else if (Password.Length < 8)
                PasswordError = "Password must be more than 8 characters";
            else
                ShowPasswordError = false;
        }

        private bool showGeneralError;

        public bool ShowGeneralError
        {
            get => showGeneralError;
            set
            {
                showGeneralError = value;
                OnPropertyChanged("ShowGeneralError");
            }
        }

        private string generalError;

        public string GeneralError
        {
            get => generalError;
            set
            {
                generalError = value;
                OnPropertyChanged("GeneralError");
            }
        }

        private bool rememberMeChecked;

        public bool RememberMeChecked
        {
            get => rememberMeChecked;
            set
            {
                rememberMeChecked = value;
                OnPropertyChanged("RememberMeChecked");
            }
        }

        private bool ValidateForm()
        {
            if (((App)App.Current).CurrentUser != null)
            {
                GeneralError = "You are already logged in";
                return false;
            }

            ValidateEmail();
            ValidatePassword();

            return !(ShowEmailError || ShowPasswordError);
        }
    }
}
