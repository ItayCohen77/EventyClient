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
using System.Threading;

namespace EventyApp.ViewModel
{
    class EditUserInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;
        private EventyAPIProxy proxy;
        public User currentUser;
        public EditUserInfoViewModel()
        {
            proxy = EventyAPIProxy.CreateProxy();
            currentUser = ((App)App.Current).CurrentUser;

            Start();
        }
        public async void Start()
        {
            this.FirstName = currentUser.FirstName;
            this.LastName = currentUser.LastName;
            this.Email = currentUser.Email;
            this.BirthDate = currentUser.BirthDate;
            this.Password = currentUser.Pass;
            this.PhoneNum = currentUser.PhoneNumber;
        }

        private string email;
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }


        private string firstname;
        public string FirstName
        {
            get
            {
                return this.firstname;
            }
            set
            {
                if (this.firstname != value)
                {
                    this.firstname = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        private string lastname;
        public string LastName
        {
            get
            {
                return this.lastname;
            }
            set
            {
                if (this.lastname != value)
                {
                    this.lastname = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        private DateTime birthdate;
        public DateTime BirthDate
        {
            get
            {
                return this.birthdate;
            }
            set
            {
                if (this.birthdate != value)
                {
                    this.birthdate = value;
                    OnPropertyChanged(nameof(BirthDate));
                }
            }
        }

        private string phonenum;
        public string PhoneNum
        {
            get
            {
                return this.phonenum;
            }
            set
            {
                if (this.phonenum != value)
                {
                    this.phonenum = value;
                    OnPropertyChanged(nameof(PhoneNum));
                }
            }
        }

        public Command UpdateCommand => new Command(Update);
        public async void Update()
        {
            //if (ValidateForm())
            //{

                bool updateProfileSuccess = await proxy.UpdateProfileInfo(FirstName, LastName, PhoneNum, Password);
                if (updateProfileSuccess)
                {
                    currentUser.FirstName = FirstName;
                    currentUser.LastName = LastName;
                    currentUser.PhoneNumber = PhoneNum;
                    currentUser.Pass = Password;
                }

                Push.Invoke(new TabControlView());
            //}
        }
    }
}
