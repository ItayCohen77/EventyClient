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
    class ChoosePlaceORViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;

        private EventyAPIProxy proxy;

        public ChoosePlaceORViewModel(string city, DateTime date, int peopleAmount, TimeSpan startTime, TimeSpan endTime, int totalHours)
        {
            this.City = city;
            this.EventDate = date;
            this.PeopleAmount = peopleAmount;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.TotalHours = totalHours;
            proxy = EventyAPIProxy.CreateProxy();
            FoundPlaces = new ObservableCollection<Place>();
            GetPlacesByCity();
            this.PlaceCommand = new Command<Place>((p) => ShowPlace(p));
        }

        private ObservableCollection<Place> foundPlaces;
        public ObservableCollection<Place> FoundPlaces
        {
            get => foundPlaces;
            set
            {
                foundPlaces = value;
                OnPropertyChanged("FoundPlaces");
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
                    OnPropertyChanged(nameof(EndTime));
                }
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
        public async void GetPlacesByCity()
        {
            List<Place> placesByCity = await proxy.GetPlacesByCity(City);

            foreach (Place place in placesByCity)
            {
                bool haveEvent = HaveEventInDate(place);

                if(place.TotalOccupancy > PeopleAmount && !haveEvent)
                {
                    FoundPlaces.Add(place);
                }
                    
            }
        }

        public bool HaveEventInDate(Place p)
        {
            foreach (Order order in p.Orders)
            {
                if (order.EventDate == EventDate)
                {
                    return true;
                }
            }

            return false;
        }

        public Command PlaceCommand { protected set; get; }
        private void ShowPlace(Place p)
        {
            Push.Invoke(new EventyApp.Views.OrderEstateView.PlaceORView(City, EventDate, PeopleAmount, StartTime, EndTime, TotalHours, p.Id));
        }
    }
}
