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
    class ChooseHourORViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;

        private EventyAPIProxy proxy;

        public ChooseHourORViewModel(string city, DateTime date, int peopleAmount)
        {
            this.City = city;
            this.EventDate = date;
            this.PeopleAmount = peopleAmount;
            UpdateHour();
        }

        public void UpdateHour()
        {
            this.TotalHours = (this.EndTime - this.StartTime).Hours;
            
            if(this.TotalHours < 0)
            {
                this.TotalHours = 0;
            }
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

        private TimeSpan startTime;
        public TimeSpan StartTime
        {
            get
            {
                return this.startTime;
            }
            set
            {
                if (this.startTime != value)
                {
                    this.startTime = value;
                    UpdateHour();
                    OnPropertyChanged(nameof(StartTime));                   
                }
            }
        }

        private TimeSpan endTime;
        public TimeSpan EndTime
        {
            get
            {
                return this.endTime;
            }
            set
            {
                if (this.endTime != value)
                {
                    this.endTime = value;
                    UpdateHour();
                    OnPropertyChanged(nameof(EndTime));
                }
            }
        }

        private int totalHours;
        public int TotalHours
        {
            get
            {
                return this.totalHours;
            }
            set
            {
                if (this.totalHours != value)
                {
                    this.totalHours = value;
                    OnPropertyChanged(nameof(TotalHours));
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

        private string totalhoursError;
        public string TotalhoursError
        {
            get
            {
                return this.totalhoursError;
            }
            set
            {
                if (this.totalhoursError != value)
                {
                    this.totalhoursError = value;
                    OnPropertyChanged(nameof(TotalhoursError));
                }
            }
        }

        private bool showtotalhoursError;
        public bool ShowtotalhoursError
        {
            get
            {
                return this.showtotalhoursError;
            }
            set
            {
                if (this.showtotalhoursError != value)
                {
                    this.showtotalhoursError = value;
                    OnPropertyChanged(nameof(ShowtotalhoursError));
                }
            }
        }

        private void ValidateTotalHours()
        {
            if (TotalHours == 0)
            {
                this.TotalhoursError = "Total hours must be higher than 0";
                this.ShowtotalhoursError = true;
            }
            else
            {
                this.ShowtotalhoursError = false;
            }
        }
        private bool ValidateForm()
        {
            ValidateTotalHours();

            return !(ShowtotalhoursError);
        }

        public Command NextCommand => new Command(Next);
        private void Next()
        {
            if(ValidateForm())
            {
                Push?.Invoke(new EventyApp.Views.OrderEstateView.ChoosePlaceORView(City, EventDate, PeopleAmount, StartTime, EndTime, TotalHours));
            }           
        }
    }
}
