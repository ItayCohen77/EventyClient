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
    class EditPlaceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event Action<Page> Push;
        private EventyAPIProxy proxy;
        public User currentUser;

        public EditPlaceViewModel(Place p)
        {
            proxy = EventyAPIProxy.CreateProxy();
            currentUser = ((App)App.Current).CurrentUser;
            this.Place = p;
            this.TotalOccupancy = Place.TotalOccupancy;
            this.Summary = Place.Summary;
            this.PlaceAddress = Place.PlaceAddress;
            this.Apartment = Place.Apartment;
            this.City = Place.City;
            this.Zip = Place.Zip;
            this.Country = Place.Country;
            this.Price= Place.Price;
        }    

        private int totalOccupancy;
        public int TotalOccupancy
        {
            get
            {
                return this.totalOccupancy;
            }
            set
            {
                if (this.totalOccupancy != value)
                {
                    this.totalOccupancy = value;
                    OnPropertyChanged(nameof(TotalOccupancy));
                }
            }
        }

        private string summary;
        public string Summary
        {
            get
            {
                return this.summary;
            }
            set
            {
                if (this.summary != value)
                {
                    this.summary = value;
                    OnPropertyChanged(nameof(Summary));
                }
            }
        }

        private string placeAddress;
        public string PlaceAddress
        {
            get
            {
                return this.placeAddress;
            }
            set
            {
                if (this.placeAddress != value)
                {
                    this.placeAddress = value;
                    OnPropertyChanged(nameof(PlaceAddress));
                }
            }
        }

        private string apartment;
        public string Apartment
        {
            get
            {
                return this.apartment;
            }
            set
            {
                if (this.apartment != value)
                {
                    this.apartment = value;
                    OnPropertyChanged(nameof(Apartment));
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

        private string zip;
        public string Zip
        {
            get
            {
                return this.zip;
            }
            set
            {
                if (this.zip != value)
                {
                    this.zip = value;
                    OnPropertyChanged(nameof(Zip));
                }
            }
        }

        private string country;
        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                if (this.country != value)
                {
                    this.country = value;
                    OnPropertyChanged(nameof(Country));
                }
            }
        }

        private int price;
        public int Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (this.price != value)
                {
                    this.price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        private Place place;
        public Place Place
        {
            get
            {
                return this.place;
            }
            set
            {
                if (this.place != value)
                {
                    this.place = value;
                    OnPropertyChanged(nameof(Place));
                }
            }
        }

        public Command UpdateCommand => new Command(Update);
        public async void Update()
        {
            //if (ValidateForm())
            //{

            bool updatePlaceSuccess = await proxy.UpdatePlace(TotalOccupancy, Summary, PlaceAddress, Apartment, City, Zip, Country, Price, Place.Id);
            if (updatePlaceSuccess)
            {
                Place.TotalOccupancy = this.TotalOccupancy;
                Place.Summary = this.Summary;
                Place.PlaceAddress = this.PlaceAddress;
                Place.Apartment = this.Apartment;
                Place.City = this.City;
                Place.Zip = this.Zip;
                Place.Country = this.Country;
                Place.Price = this.Price;
            }

            Push.Invoke(new TabControlView());
            //}
        }

        //public Command DeleteCommand => new Command(Delete);
        //public async void Delete()
        //{
        //    //if (ValidateForm())
        //    //{

            

        //    Push.Invoke(new TabControlView());
        //    //}
        //}
    }
}
