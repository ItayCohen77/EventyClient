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
    class ChooseDatesORViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;
        private EventyAPIProxy proxy;
        public User currentUser;
        public ChooseDatesORViewModel(string city)
        {
            Start(city);                 
        }

        public async void Start(string city)
        {
            currentUser = ((App)App.Current).CurrentUser;
            if (currentUser == null)
            {
                bool notLog = await AlertLogIn();

                if(notLog)
                {
                    await PopAllTo(new EventyApp.Views.LoginView());
                }
                else
                {
                    await PopAllTo(new EventyApp.Views.SignUpView());
                }              
            }
            else
            {
                this.City = city;
            }           
        }

        public async Task<bool> AlertLogIn()
        {
            bool notLogin = await App.Current.MainPage.DisplayAlert("Alert", "You must log in/sign up for search a place", "Log In", "Sign Up");

            return notLogin;
        }

        public async Task PopAllTo(Page page) // clear navigation stack and goes to page
        {
            App.Current.MainPage.Navigation.InsertPageBefore(page, App.Current.MainPage.Navigation.NavigationStack.First());
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }

        private DateTime eventDate;
        public DateTime EventDate
        {
            get
            {
                return this.eventDate;
            }
            set
            {
                if (this.eventDate != value)
                {
                    this.eventDate = value;
                    OnPropertyChanged(nameof(EventDate));
                }
            }
        }

        private int peopleAmount;
        public int PeopleAmount
        {
            get
            {
                return this.peopleAmount;
            }
            set
            {
                if (this.peopleAmount != value)
                {
                    this.peopleAmount = value;
                    OnPropertyChanged(nameof(PeopleAmount));
                }
            }
        }

        private string city;
        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                if (this.city != value)
                {
                    this.city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        private bool showDateError;
        public bool ShowDateError
        {
            get
            {
                return this.showDateError;
            }
            set
            {
                if (this.showDateError != value)
                {
                    this.showDateError = value;
                    OnPropertyChanged(nameof(ShowDateError));
                }
            }
        }

        private bool showPeopleAmountError;
        public bool ShowPeopleAmountError
        {
            get
            {
                return this.showPeopleAmountError;
            }
            set
            {
                if (this.showPeopleAmountError != value)
                {
                    this.showPeopleAmountError = value;
                    OnPropertyChanged(nameof(ShowPeopleAmountError));
                }
            }
        }

        private string dateError;
        public string DateError
        {
            get
            {
                return this.dateError;
            }
            set
            {
                if (this.dateError != value)
                {
                    this.dateError = value;
                    OnPropertyChanged(nameof(DateError));
                }
            }
        }

        private string peopleAmountError;
        public string PeopleAmountError
        {
            get
            {
                return this.peopleAmountError;
            }
            set
            {
                if (this.peopleAmountError != value)
                {
                    this.peopleAmountError = value;
                    OnPropertyChanged(nameof(PeopleAmountError));
                }
            }
        }
        private void ValidateDate()
        {
            if (EventDate < DateTime.Now)
            {
                this.DateError = "Please choose a date which is after today";
                this.ShowDateError = true;
            }
            else
            {
                this.ShowDateError = false;
            }
        }
        private void ValidatePeopleAmount()
        {
            if (PeopleAmount == 0)
            {
                this.PeopleAmountError = "People amount must be higher than 0";
                this.ShowPeopleAmountError = true;
            }
            else
            {
                this.ShowPeopleAmountError = false;
            }
        }
        private bool ValidateForm()
        {
            ValidateDate();
            ValidatePeopleAmount();

            return !(ShowDateError || ShowPeopleAmountError);
        }

        public Command NextCommand => new Command(Next);
        private void Next()
        {
            if(ValidateForm())
            {
                Push?.Invoke(new EventyApp.Views.OrderEstateView.ChooseHourORView(City, EventDate, PeopleAmount));
            }           
        }
    }
}
