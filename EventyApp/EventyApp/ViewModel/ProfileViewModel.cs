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

        private bool notlogIn;
        public bool NotLogIn
        {
            get
            {
                return this.notlogIn;
            }
            set
            {
                if (this.notlogIn != value)
                {
                    this.notlogIn = value;
                    OnPropertyChanged(nameof(NotLogIn));
                }
            }
        }

        private bool yeslogIn;
        public bool YesLogIn
        {
            get
            {
                return this.yeslogIn;
            }
            set
            {
                if (this.yeslogIn != value)
                {
                    this.yeslogIn = value;
                    OnPropertyChanged(nameof(YesLogIn));
                }
            }
        }

        private string fullname;
        public string FullName
        {
            get
            {
                return this.fullname;
            }
            set
            {
                if (this.fullname != value)
                {
                    this.fullname = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        private DateTime joinedAt;
        public DateTime JoinedAt
        {
            get
            {
                return this.joinedAt;
            }
            set
            {
                if (this.joinedAt != value)
                {
                    this.joinedAt = value;
                    OnPropertyChanged(nameof(JoinedAt));
                }
            }
        }

        public ProfileViewModel()
        {
            if (((App)App.Current).CurrentUser == null)
            {
                NotLogIn = true;
                YesLogIn = false;
            }
            else
            {
                NotLogIn = false;
                YesLogIn = true;
                FullName = $"{((App)App.Current).CurrentUser.FirstName} {((App)App.Current).CurrentUser.LastName}";
                JoinedAt = ((App)App.Current).CurrentUser.CreatedAt.Date;
            }
        }

        public ICommand LogInCommand => new Command(LogIn);
        private void LogIn()
        {
            Push?.Invoke(new LoginView());
        }

        public ICommand LogOutCommand => new Command(LogOut);
        private void LogOut()
        {
            ((App)App.Current).CurrentUser = null;
            Push?.Invoke(new TabControlView());
        }

        public ICommand SignUpCommand => new Command(SignUp);
        private void SignUp()
        {
            Push?.Invoke(new SignUpView());
        }
        public ICommand HostCommand => new Command(Host);
        private void Host()
        {
            Push?.Invoke(new EventyApp.Views.HostEstateView.WelcomeHEView());
        } 
    }
}
