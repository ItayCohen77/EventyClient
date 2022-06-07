using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using EventyApp.Services;
using EventyApp.Models;
using Xamarin.Essentials;
using System.Linq;
using EventyApp.Views;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using System.Collections.ObjectModel;
using System.Threading;

namespace EventyApp.ViewModel
{
    class ExploreViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public event Action<Page> Push;
        private List<string> citiesList;
        private EventyAPIProxy proxy;
        
        public ExploreViewModel()
        {
            App app = (App)App.Current;
            citiesList = null;
            proxy = EventyAPIProxy.CreateProxy();
            SetCities();
            this.FilteredCities = new ObservableCollection<string>();;
            FoundPlaces = new ObservableCollection<Place>();
            this.ShowCityError = false;
            this.CityError = "Bad city";
            this.Height = 42;
            this.Radius = 50;
            Start();          
        }
        public async void Start()
        {
            await GetLocation();
            GetPlacesByCity();
        }
        public async void SetCities()
        {
            this.citiesList = await proxy.GetCities();
        }       
        public async Task GetLocation()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location != null)
                await GetCityLocation(location);
            else
            {
                this.CurrentCity = "Hod hasharon";
            }
        }

        public async Task GetCityLocation(Location location)
        {
            var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
            var placemark = placemarks?.FirstOrDefault();

            if (placemark != null)
            {
                this.CurrentCity = placemark.Locality;
            }               
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

        private ObservableCollection<string> filteredCities;
        public ObservableCollection<string> FilteredCities
        {
            get
            {
                return this.filteredCities;
            }
            set
            {
                if (this.filteredCities != value)
                {

                    this.filteredCities = value;
                    OnPropertyChanged("FilteredCities");
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
                    OnCityChanged(value);
                    ValidateCity();
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        private string currentCity;
        public string CurrentCity
        {
            get
            {
                return this.currentCity;
            }
            set
            {
                if (this.currentCity != value)
                {
                    this.currentCity = value;
                    OnCityChanged(value);
                    OnPropertyChanged(nameof(CurrentCity));
                }
            }
        }

        private bool showCityError;
        public bool ShowCityError
        {
            get => showCityError;
            set
            {
                showCityError = value;
                OnPropertyChanged("ShowCityError");
            }
        }

        private string selectedCityItem;
        public string SelectedCityItem
        {
            get => selectedCityItem;
            set
            {
                selectedCityItem = value;
                OnPropertyChanged("SelectedCityItem");
            }
        }

        private bool showCities;
        public bool ShowCities
        {
            get => showCities;
            set
            {
                showCities = value;
                OnPropertyChanged("ShowCities");
            }
        }

        private int height;
        public int Height
        {
            get => height;
            set
            {
                height = value;
                OnPropertyChanged("Height");
            }
        }

        private int radius;
        public int Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged("Radius");
            }
        }

        private string cityError;
        public string CityError
        {
            get => cityError;
            set
            {
                cityError = value;
                OnPropertyChanged("CityError");
            }
        }

        private ObservableCollection<string> foundCitys;
        public ObservableCollection<string> FoundCitys
        {
            get
            {
                return this.foundCitys;
            }
            set
            {
                if (this.foundCitys != value)
                {
                    this.foundCitys = value;
                    OnPropertyChanged(nameof(FoundCitys));
                }
            }
        }

        private void ValidateCity()
        {
            this.ShowCityError = string.IsNullOrEmpty(this.City);
            if (!this.ShowCityError)
            {
                string city = this.citiesList.Where(c => c == this.City).FirstOrDefault();
                if (string.IsNullOrEmpty(city))
                {
                    this.ShowCityError = true;
                    this.CityError = "Bad city";
                }
            }
        }

        public void OnCityChanged(string search)
        {
            if (this.City != this.SelectedCityItem)
            {
                this.ShowCities = true;
                this.Height = 150;
                this.Radius = 25;
                this.SelectedCityItem = null;
            }
            //Filter the list of cities based on the search term
            if (this.citiesList == null)
                return;
            if (String.IsNullOrWhiteSpace(search) || String.IsNullOrEmpty(search))
            {
                this.ShowCities = false;
                this.Height = 42;
                this.Radius = 50;
                this.FilteredCities.Clear();
            }
            else
            {
                foreach (string city in this.citiesList)
                {
                    if (!this.FilteredCities.Contains(city) &&
                        city.Contains(search))
                        this.FilteredCities.Add(city);
                    else if (this.FilteredCities.Contains(city) &&
                        !city.Contains(search))
                        this.FilteredCities.Remove(city);
                }
            }
        }
        public async Task GetPlacesByCity()
        {
            List<Place> placesByCity = await proxy.GetPlacesByCity(CurrentCity);

            foreach (Place place in placesByCity)
            {
                FoundPlaces.Add(place);
            }
        }

        public ICommand SelectedCity => new Command<string>(OnSelectedCity);
        public void OnSelectedCity(string city)
        {
            if (city != null)
            {
                this.ShowCities = false;
                this.Height = 42;
                this.Radius = 50;
                this.City = city;
            }
        }
        public Command SearchCommand => new Command(StartOrder);
        private void StartOrder()
        {
            Push?.Invoke(new EventyApp.Views.OrderEstateView.ChooseDatesORView(City));
        }
    }
}
